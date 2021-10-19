using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CraftingMenu : MonoBehaviour
{

    [SerializeField] List<Item> craftables = null;
    [SerializeField] PlayerInventory playerInventory;
    [SerializeField] Image selectedItemSprite, previousItemSprite, nextItemSprite, itemRecipeType;
    [SerializeField] TextMeshProUGUI itemDesc, itemName, itemDamage, itemSwingSpeed, itemType, itemRecipe;
    AudioSource src;
    int selectedIndex = 0;
    bool isInitialStartup = true;

    private void Awake()
    {
        src = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        //Grabs craftables initially that way there are no repeats in tool crafting
        if(isInitialStartup)
        {
            craftables = GameManager.instance.GetItems();
            isInitialStartup = false;
        }
        
        CleanOutCraftables();
        SetItemSprites();
    }

    /// <summary>
    /// Clean out the craftables list to only show items the player needs!
    /// </summary>
    void CleanOutCraftables()
    {
        //Gets a list of the players current items in the inventory
        List<Item> currentItems = playerInventory.GetCurrentAllItems();

        //Goes through the list and deletes the like items. So if the player already has a copper sword, the copper sword wont show up in the craftables menu!
        for (int i = 0; i < currentItems.Count; i++)
        {
            if (craftables.Contains(currentItems[i]) && !currentItems[i].repeatCrafting)
                craftables.Remove(currentItems[i]);
        }

        //Go through the list, remove any lower tier items that share the same type!
        for (int i = 0; i < currentItems.Count; i++)
        {
            if(currentItems[i].tier > 0)
            {
                for (int j = 0; j < craftables.Count; j++)
                {
                    if (craftables[j].tier < currentItems[i].tier && craftables[j].itemType == currentItems[i].itemType)
                        craftables.RemoveAt(j--);
                }
            }
        }
    }


    /// <summary>
    /// Switch the selected index!
    /// </summary>
    /// <param name="val"></param>
    public void SwitchIndex(int val)
    {
        selectedIndex += val;
        if (selectedIndex > craftables.Count - 1)
            selectedIndex = craftables.Count - 1;
        if (selectedIndex < 0)
            selectedIndex = 0;
        SetItemSprites();
    }

    /// <summary>
    /// Set the previous, current and next sprite images for craftable items!
    /// </summary>
    void SetItemSprites()
    {
        //We need to check the indexes to make sure we arent break the arrays
        if(craftables.Count > 0)
        {
            if(selectedIndex - 1 >= 0)
                SetSprite(craftables[selectedIndex - 1], previousItemSprite);
            else
                SetSprite(null, previousItemSprite);

            SetSprite(craftables[selectedIndex], selectedItemSprite);

            if(selectedIndex + 1 <= craftables.Count - 1)
                SetSprite(craftables[selectedIndex + 1], nextItemSprite);
            else
                SetSprite(null, nextItemSprite);
        } else
        {
            SetSprite(null, selectedItemSprite);
        }
        SetItemInfo();
    }

    void SetItemInfo()
    {
        itemName.text = craftables[selectedIndex].itemName;
        itemDesc.text = craftables[selectedIndex].itemDesc;
        itemDamage.text = "Damage: " + craftables[selectedIndex].damage.ToString();
        itemSwingSpeed.text = "Speed: " + craftables[selectedIndex].coolDown.ToString();
        itemRecipe.text = craftables[selectedIndex].recipe.requiredAmount.ToString();
        itemRecipeType.sprite = craftables[selectedIndex].recipe.requiredResourceSprite;
        itemType.text = craftables[selectedIndex].itemType.ToString();
    }
    /// <summary>
    /// Craft the chosen item if it exists!
    /// </summary>
    public void CraftSelectedItem()
    {
        //First check to make sure the player can craft the item.
        if(craftables.Count > 0)
        {
            Recipe selectedRecipe = craftables[selectedIndex].recipe;
            if(selectedRecipe == null)
            {
                print("Crafting recipe is null");
                return;
            }
            if (playerInventory.GetRefinedResourceAmount(selectedRecipe.requiredResource) >= selectedRecipe.requiredAmount)
            {
                //Craft!
                playerInventory.ModifyRefinedResource(selectedRecipe.requiredResource, -selectedRecipe.requiredAmount);
                playerInventory.AddItem(craftables[selectedIndex].itemType, craftables[selectedIndex]);
                CleanOutCraftables();
                SwitchIndex(0);
                src.Play();
            }
            else
            {
                //Create a pop up for the player here and maybe an error sound?
                print("Cannot afford! Need: " + selectedRecipe.requiredResource + ", " + selectedRecipe.requiredAmount);
            }
        }
        
    }

    /// <summary>
    /// A generic sprite method used for all the image sprites
    /// </summary>
    /// <param name="item"></param>
    /// <param name="image"></param>
    void SetSprite(Item item, Image image)
    {
        if (item != null)
        {
            image.enabled = true;
            image.sprite = item.sprite;
        }
            
        else
        {
            image.enabled = false;
        }
            
    }

    public Image GetSelectedItemSprite() { return selectedItemSprite; }
    public Item GetSelectedItem() { return craftables[selectedIndex]; }
    public PlayerInventory GetPlayerInventory() { return playerInventory; }


}
