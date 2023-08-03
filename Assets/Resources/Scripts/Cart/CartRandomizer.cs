using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class CartRandomizer
{
    private const int PROCENT_CHANCE = 75;

    private Item[] items;

    private const int MAX_ITEMS = 3;

    private List<Item> itemsForSell;

    public CartRandomizer(Item[] items)
    {
        this.items = items;
    }
    
    public bool IsSpawn()
    {
        float chance = Random.Range(0f, 100f);

        return chance < PROCENT_CHANCE;
    }

    public Item[] RandomizeItems()
    {
        itemsForSell = new List<Item>();

        Debug.Log("1");

        for (int i = 0; i < MAX_ITEMS; i++)
        {
            itemsForSell.Add(RandomizeItem());
        }

        return itemsForSell.ToArray();
    }

    public Item RandomizeItem()
    {
        Item item = items[Random.Range(0, items.Length)];

        if (itemsForSell.Contains(item))
        {
            return RandomizeItem();
        }

        return item;
    }
}
