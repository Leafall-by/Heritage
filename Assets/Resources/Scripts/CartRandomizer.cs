using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CartRandomizer
{
    private const int PROCENT_CHANCE = 33;

    private Item[] items;

    private Cart cart;

    public CartRandomizer(Item[] items, Cart cart)
    {
        this.items = items;
        this.cart = cart;
    }
    
    public bool IsSpawn()
    {
        float chance = Random.Range(0f, 100f);

        return chance < PROCENT_CHANCE;
    }

    public Cart GetCart()
    {
        cart.SetItems(RandomizeItems());
        return cart;
    }

    private Item[] RandomizeItems()
    {
        Item[] itemsForSell = new Item[3];

        for (int i = 0; i < itemsForSell.Length; i++)
        {
            itemsForSell[i] = items[Random.Range(0, items.Length)];
        }
        
        return itemsForSell;
    }
}
