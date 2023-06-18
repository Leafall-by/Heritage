using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField] private Player player;
    private Item[] items;
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

    private void ShowShop(Item[] items)
    {
        shopUI.SetItemsUI(items);
    }
    
    public void SetItems(Item[] items)
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
            Debug.Log(ex.Message);
            return;
        }
        
        player.Inventory.AddItem(items[index]);
        items[index] = null;
        
        shopUI.DeleteItemUI(index);
    }
}
