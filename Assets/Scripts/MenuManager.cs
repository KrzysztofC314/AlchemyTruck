using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject craftingMenu;
    [SerializeField] private InventoryManager inventoryManager;
    [HideInInspector] public bool isCMenuActive;
    // Start is called before the first frame update
    void Start()
    {
        craftingMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isCMenuActive = !isCMenuActive;
            craftingMenu.SetActive(isCMenuActive);
            inventoryManager.ListItems();
        }
    }
}
