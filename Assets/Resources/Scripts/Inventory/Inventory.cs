using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class Inventory
{
    private int maxTools = 3;
    private int maxItems = 6;

    private List<ItemState> items;
    private List<Tool> tools;

    public Inventory()
    {
        items = new List<ItemState>();
        tools = new List<Tool>();
    }
    
    public void AddItem(Item item)
    {
        if (item is Tool tool && tools.Count < maxTools)
        {
            tools.Add(tool);
            return;
        }
        
        foreach (var itemClass in items) //если пришёл не инструмент, то найти стопку таких же предметов и добавить туда
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

    public ItemState[] GetItems()
    {
        return items.ToArray();
    }

    public Tool[] GetTools()
    {
        return tools.ToArray();
    }
}
