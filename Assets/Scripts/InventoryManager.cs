using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        item.value++;
        if(item.value <= 1)
        {
            Items.Add(item);
        }
        ListItems();
    }

    public void Remove(Item item)
    {
        if(item.value > 0)
        {
            item.value--;
            if(item.value <= 0)
            {
                Items.Remove(item);
            }
        }
        ListItems();
    }

    public void ListItems()
    {
        foreach(Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
        foreach(var item in Items)
        {
            if (item.value > 0)
            {
                GameObject obj = Instantiate(InventoryItem, ItemContent);
                var itemName = obj.transform.Find("ItemName").GetComponent<TMPro.TextMeshProUGUI>();
                var itemIcon = obj.transform.Find("Image").GetComponent<Image>();
                var itemValue = obj.transform.Find("ItemValue").GetComponent<TMPro.TextMeshProUGUI>();
                ItemBag itemBag = obj.GetComponent<ItemBag>();

                itemBag.item = item;
                itemName.text = item.itemName;
                itemIcon.sprite = item.icon;
                itemValue.text = item.value.ToString();
            }
        }
    }
}
