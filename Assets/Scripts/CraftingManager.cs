using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
    public InventoryManager inventoryManager;
    private Item currentItem;
    public Image customCursor;
    public Slot[] craftingSlots;

    public List<Item> itemList;
    public Recipe[] recipes;
    public Recipe SavedRecipe;
    public Slot resultSlot;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (currentItem != null)
            {
                customCursor.gameObject.SetActive(false);
                Slot nearestSlot = null;
                float shortestDistance = float.MaxValue;

                foreach(Slot slot in craftingSlots)
                {
                    float dist = Vector2.Distance(Input.mousePosition, slot.transform.position);

                    if(dist < shortestDistance)
                    {
                        shortestDistance = dist;
                        nearestSlot = slot;
                    }
                }
                nearestSlot.gameObject.SetActive(true);
                nearestSlot.GetComponent<Image>().sprite = currentItem.icon;
                nearestSlot.item = currentItem;
                itemList[nearestSlot.index] = currentItem;
                currentItem = null;
                CheckForCreatedRecipes();
            }
        }
    }

    void CheckForCreatedRecipes()
    {
        resultSlot.gameObject.SetActive(false);
        resultSlot.item = null;

        string currentRecipeString = "";
        foreach (Item item in itemList)
        {
            if (item != null)
            {
                currentRecipeString += item.itemName;
            }
            else
            {
                currentRecipeString += "null";
            }
        }

        for (int i = 0; i< recipes.Length; i++)
        {
            recipes[i].GetRecipeCode();
            Debug.Log("Looking for recipe");
            Debug.Log(recipes[i].recipeCode+"/"+currentRecipeString);

            if (recipes[i].recipeCode == currentRecipeString)
            {
                Debug.Log("Recipe Found!");
                SavedRecipe = recipes[i];
                resultSlot.gameObject.SetActive(true);
                resultSlot.GetComponent<Image>().sprite = recipes[i].result.icon;
                resultSlot.item = recipes[i].result;
                //inventoryManager.Add(resultSlot.item);
            }
        }
    }

    public void OnClickSlot(Slot slot)
    {
        slot.item = null;
        itemList[slot.index] = null;
        slot.gameObject.SetActive(false);
        CheckForCreatedRecipes();
    }

    public void OnMouseDownItem(Item item)
    {
        Debug.Log("Clicked");

        if (currentItem == null)
        {
            currentItem = item;
            customCursor.gameObject.SetActive(true);
            customCursor.sprite = currentItem.icon;
            //inventoryManager.Remove(currentItem);
        }
    }

    public void OnClickResultSlot()
    {
        
        if (SavedRecipe != null)
        {
            Debug.Log("Pressed");
            foreach (Item item in SavedRecipe.recipe)
            {
                if(item != null)
                {
                    inventoryManager.Remove(item);
                }
            }
            inventoryManager.Add(SavedRecipe.result);
            foreach(Slot slot in craftingSlots)
            {
                slot.gameObject.SetActive(false);
            }
            resultSlot.gameObject.SetActive(false);
        }
    }
}
