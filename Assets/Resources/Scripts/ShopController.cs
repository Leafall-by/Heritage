using System;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField] private NotificaitionController notificationController;
    [SerializeField] private Player player;
    private List<Item> items;
    [SerializeField] private ShopUI shopUI;

    private float discount;
    public float Discount
    {
        get
        {
            return discount;
        }
        set
        {
            discount = value;
            if (discount > 100)
                discount = 100;
            else if (discount < 0)
                discount = 0;
        }
    }

    private void ShowShop(List<Item> items)
    {
        shopUI.SetItemsUI(items, Discount);
    }
    
    public void SetItems(List<Item> items)
    {
        this.items = items;

        ShowShop(items);
    }

    public void BuyItem(int index)
    {
        try
        {
            player.Wallet.RemoveGold((int)Math.Ceiling(items[index].price - (items[index].price * (discount/100.0))));
        }
        catch (NotEnoughGoldException ex)
        {
            notificationController.ShowNotification("�� ���������� �����");
            return;
        }

        player.Inventory.AddItem(items[index]);
        items[index] = null;
        
        shopUI.DeleteItemUI(index);
    }
}
