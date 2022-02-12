using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Customizer : MonoBehaviour
{
    [SerializeField] CustomizerCategory[] categories;
    [SerializeField] int selectedCategory = 0;
    [SerializeField] Image nextCategoryImage, previousCategoryImage, selectedCategoryImage;

    private void Awake()
    {
        SetCategorySprites();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
            Destroy(this.gameObject);
    }
    /// <summary>
    /// Called From Input
    /// </summary>
    /// <param name="callback"></param>
    public void SwitchCategoryRight(InputAction.CallbackContext callback)
    {
        if (gameObject.activeInHierarchy && callback.performed)
            SwitchCategory(1);
    }

    /// <summary>
    /// Called From Input
    /// </summary>
    /// <param name="callback"></param>
    public void SwitchCategoryLeft(InputAction.CallbackContext callback)
    {
        if(gameObject.activeInHierarchy && callback.performed)
            SwitchCategory(-1);
    }

    /// <summary>
    /// Called From Input
    /// </summary>
    /// <param name="callback"></param>
    public void SwitchOptionRight(InputAction.CallbackContext callback)
    {
        if (gameObject.activeInHierarchy && callback.performed)
            SwitchOption(1);
    }

    /// <summary>
    /// Called From Input
    /// </summary>
    /// <param name="callback"></param>
    public void SwitchOptionLeft(InputAction.CallbackContext callback)
    {
        if (gameObject.activeInHierarchy && callback.performed)
            SwitchOption(-1);
    }
    /// <summary>
    /// Determines which customization option is selected and changes the selected option of that option.
    /// </summary>
    /// <param name="val"></param>
    /// <param name="callback"></param>
    void SwitchOption(int val)
    {
        categories[selectedCategory].SwitchOption(val);
    }
    /// <summary>
    /// Switches the current selected category for customization
    /// </summary>
    /// <param name="val"></param>
    void SwitchCategory(int val)
    {
        selectedCategory += val;
        if (selectedCategory < 0)
            selectedCategory = 0;
        else if (selectedCategory > categories.Length - 1)
            selectedCategory = categories.Length - 1;
        SetCategorySprites();
        SwitchOption(0);
    }
    void SetCategorySprites()
    {
        //We need to check the indexes to make sure we arent break the arrays
        if (categories.Length > 0)
        {
            if (selectedCategory - 1 >= 0)
                SetSprite(categories[selectedCategory - 1], previousCategoryImage);
            else
                SetSprite(null, previousCategoryImage);

            SetSprite(categories[selectedCategory], selectedCategoryImage);

            if (selectedCategory + 1 <= categories.Length - 1)
                SetSprite(categories[selectedCategory + 1], nextCategoryImage);
            else
                SetSprite(null, nextCategoryImage);
        }
        else
        {
            SetSprite(null, selectedCategoryImage);
        }
    }

    /// <summary>
    /// A generic sprite method used for all the image sprites
    /// </summary>
    /// <param name="item"></param>
    /// <param name="image"></param>
    void SetSprite(CustomizerCategory item, Image image)
    {
        if (item != null)
        {
            image.enabled = true;
            image.sprite = item.categorySprite;
        }

        else
        {
            image.enabled = false;
        }

    }
}
