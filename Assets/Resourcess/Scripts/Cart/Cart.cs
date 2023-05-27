using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    private const int COUNT_ITEMS_FOR_SELL = 3;
    
    public Item[] items = new Item[COUNT_ITEMS_FOR_SELL];

    private ShopController controller;

    public void SetItems(Item[] items)
    {
        this.items = items;
    }

    public void ShowShop()
    {
        controller.SetItems(items);
    }

    public void SetShopController(ShopController controller)
    {
        this.controller = controller;
    }
}
