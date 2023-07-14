using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
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
    
    public void AddItem(Item itemPrefab)
    {
        Debug.Log("fdsfs");
        Item item = Instantiate(itemPrefab);
        item.gameObject.SetActive(false);
        
        if (item is Tool tool && tools.Count < maxTools)
        {
            tools.Add(tool);
            return;
        }

        ItemState itemState = FindItemState(item);
        if (itemState != null)
        {
            itemState.count++;
            return;
        }
        
        if (items.Count == maxItems)
            return;
        
        items.Add(new ItemState(item));
    }
    
    public void RemoveItem(Item item)
    {
        if (item is Tool tool && tools.Count < maxTools)
        {
            tools.Remove(tool);
            Destroy(item.gameObject);
            return;
        }

        for (int i = 0; i < items.Count; i++)
        {
            if (item.image == items[i].item.image)
            {
                items[i].count--;

                if (items[i].count == 0)
                {
                    items.Remove(FindItemState(item));
                }
            }
        }
        
        Destroy(item.gameObject);
    }
    
    private ItemState FindItemState(Item item)
    {
        foreach (var itemClass in items) //если пришёл не инструмент, то найти стопку таких же предметов и добавить туда
        {
            if (item.image == itemClass.item.image)
            {
                return itemClass;
            }
        }

        return null; //TODO выкидывать ошибку
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
