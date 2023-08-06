using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cart : MonoBehaviour
{
    private const int COUNT_ITEMS_FOR_SELL = 3;
    
    public List<Item> items = new List<Item>();

    private ShopController controller;

    public void AddItem(Item item)
    {
        
        if (items.Count == COUNT_ITEMS_FOR_SELL)
        {
            throw new Exception();
        }
        
        items.Add(item);
        
        TrySetRainColor();
    }

    public void ShowShop()
    {
        controller.SetItems(items);
    }

    public void SetShopController(ShopController controller)
    {
        this.controller = controller;
    }

    private void TrySetRainColor()
    {
        Weather weather = FindObjectOfType<Weather>();
        if (weather.IsRain)
        {
            GetComponent<Image>().color = new Color(0.6f, 0.6f, 0.6f);
        }
    }
}
