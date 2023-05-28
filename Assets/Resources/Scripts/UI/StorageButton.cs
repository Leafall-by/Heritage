using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageButton : MonoBehaviour
{
    [SerializeField] private InventoryUI inventoryUI;
    private bool isOpen;

    public void Click()
    {
        if (isOpen)
        {
            inventoryUI.CloseInventory();
            isOpen = false;
        }
        else
        {
            inventoryUI.ShowInventory();
            isOpen = true;
        }

    }
}
