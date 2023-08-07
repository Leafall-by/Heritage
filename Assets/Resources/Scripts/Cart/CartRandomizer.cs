using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

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

        for (int i = 0; i < MAX_ITEMS; i++)
        {
            itemsForSell.Add(RandomizeItem());
        }

        return itemsForSell.ToArray();
    }

    public Item RandomizeItem()
    {
        List<Item> availableItems = new List<Item>();

        int sum = 0;
        foreach (var item in items)
        {
            if ((item is IDependetForSpawn dependet && !dependet.IsCan()) || IsContains(item))
            {
                continue;
            }
            sum += item.dropChance;
            availableItems.Add(item);
        }

        int random = Random.Range(0, sum);
        for (int i = 0; i < availableItems.Count; i++)
        {
            random -= availableItems[i].dropChance;
            if (random <= 0)
            {
                return availableItems[i];
            }
        }

        throw new NullReferenceException();
    }

    private bool IsContains(Item randomItem)
    {
        bool isContains = false;
        foreach (var item in itemsForSell)
        {
            if (item == randomItem)
            {
                isContains = true;
            }
        }

        return isContains;
    }
}
