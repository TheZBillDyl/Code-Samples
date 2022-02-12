using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class CustomizerCategory : MonoBehaviour
{
    public int selectedIndex = 0;
    //Be sure to set array length
    [Header("SET THIS IN START")]
    public int arrayLength = 0;
    public Sprite categorySprite;
    public Image selectedOptionSprite, previousOptionSprite, nextOptionSprite;
    public TextMeshProUGUI optionName;

    /// <summary>
    /// Switches the current selected category for customization
    /// </summary>
    /// <param name="val"></param>
    public void SwitchOption(int val)
    {
        selectedIndex += val;
        if (selectedIndex < 0)
            selectedIndex = 0;
        else if (selectedIndex > arrayLength - 1)
            selectedIndex = arrayLength - 1;
        SetOption();
    }

    public virtual void SetOption()
    {

    }
    public virtual void SetOptionSprites()
    {
        
    }

    /// <summary>
    /// A generic sprite method used for all the image sprites
    /// </summary>
    /// <param name="item"></param>
    /// <param name="image"></param>
    protected void SetSprite(Sprite item, Image image)
    {
        if (item != null)
        {
            image.enabled = true;
            image.sprite = item;
        }

        else
        {
            image.enabled = false;
        }

    }
}


