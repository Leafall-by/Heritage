using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class CartRandomizer
{
    private Item[] items;

    private const int MAX_ITEMS = 3;

    private List<Item> itemsForSell;

    public CartRandomizer(Item[] items)
    {
        this.items = items;
    }
    
    public bool IsSpawn(int procentChance)
    {
        float chance = Random.Range(0f, 100f);

        return chance < procentChance;
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

        if (item is IDependetForSpawn dependet)
        {
            if (dependet.IsCan() == false)
            {
                return RandomizeItem();
            }
        }

        if (itemsForSell.Contains(item))
        {
            return RandomizeItem();
        }

        return item;
    }
}
