using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField] private Player player;
    private Item[] items;
    private ShopUI shopUI;

    public void Init()
    {
        shopUI = GetComponent<ShopUI>();
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
            player.Wallet.RemoveGold(items[index].price);
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
