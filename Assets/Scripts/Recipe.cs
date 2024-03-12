using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]
public class Recipe : ScriptableObject
{
    public List<Item> recipe;
    public Item result;
    [HideInInspector] public string recipeCode;
    public void GetRecipeCode()
    {
        recipeCode = "";
        foreach (Item item in recipe)
        {
            if (item != null)
            {
                recipeCode += item.itemName;
            }
            else
            {
                recipeCode += "null";
            }
        }
    }
}
