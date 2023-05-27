using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class Inventory
{
    private int maxTools = 3;
    private int maxItems = 6;

    private List<ItemState> items;

    public Inventory()
    {
        items = new List<ItemState>();
    }
    
    public void AddItem(Item item)
    {
        foreach (var itemClass in items)
        {
            if (item.image == itemClass.item.image)
            {
                itemClass.count++;
                return;
            }
        }
        
        if (items.Count == maxItems)
            return;
        
        items.Add(new ItemState(item));
    }

    public List<ItemState> GetItems()
    {
        return items;
    }
}
