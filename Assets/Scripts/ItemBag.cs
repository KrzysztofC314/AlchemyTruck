using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemBag : MonoBehaviour
{
    public Item item;
    [SerializeField]
    private GameObject manager;
    [SerializeField]
    private CraftingManager managerCrafting;
    private void Awake()
    {
        manager = GameObject.Find("Crafting Manager");
        managerCrafting = manager.GetComponent<CraftingManager>();
    }
    public void OnClick()
    {
        Operate(item);
    }
    public void Operate(Item item)
    {
        managerCrafting.OnMouseDownItem(item);
    }
}
