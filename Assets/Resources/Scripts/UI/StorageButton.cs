using UnityEngine;

public class StorageButton : MonoBehaviour
{
    [SerializeField] private InventoryUI inventoryUI;
    [SerializeField] private InventoryAnimation _inventoryAnimation;
    private bool isOpen = false;

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
        
        _inventoryAnimation.ChangeState(isOpen);
    }

    private void OnDisable()
    {
        isOpen = false;
    }
}
