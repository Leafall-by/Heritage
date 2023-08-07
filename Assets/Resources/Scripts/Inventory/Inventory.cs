using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    private int maxTools = 3;
    private int maxItems = 6;

    private List<List<ItemState>> items;
    private List<List<Tool>> tools;

    public int maxPages;

    public Inventory()
    {
        items = new List<List<ItemState>>();
        tools = new List<List<Tool>>();
        
        ExpandInventory();
    }

    public Item FindItemByType(Type typeItem)
    {
        foreach (var itemStateList in items)
        {
            foreach (var itemState in itemStateList)
            {
                if (itemState.item.GetType() == typeItem)
                {
                    return itemState.item;
                }
            }
        }

        foreach (var toolList in tools)
        {
            foreach (var tool in toolList)
            {
                if (tool.GetType() == typeItem)
                {
                    return tool;
                }
            }
        }

        return null; //TODO Кидать ошибку
    }

    public ItemState FindItemState(Type typeItem)
    {
        foreach (var itemStateList in items)
        {
            foreach (var itemState in itemStateList)
            {
                if (itemState.item.GetType() == typeItem)
                {
                    return itemState;
                }
            }
        }

        return null; // TODO Кидать ошибку
    }

    public bool CheckCanAdd(Item item)
    {
        if (item is Tool tool)
        {
            if (tools[tools.Count-1].Count == maxTools)
            {
                return false;
            }
        }

        if (items[items.Count-1].Count == maxItems)
        {
            return false;
        }

        return true;
    }
    
    public void AddItem(Item itemPrefab)
    {
        Item item = Instantiate(itemPrefab);
        item.gameObject.SetActive(false);

        if (item is Tool tool)
        {
            foreach (var listTools in tools)
            {
                if (listTools.Count < maxTools)
                {
                    listTools.Add(tool);
                    return;
                }
            }
            
        }
        
        ItemState itemState = FindItemState(item);
        if (itemState != null)
        {
            itemState.count++;
            return;
        }

        foreach (var listItems in items)
        {
            if (listItems.Count < maxItems)
            {
                listItems.Add(new ItemState(item));
                return;
            }
        }
    }
    
    public void RemoveItem(Item item)
    {
        if (item is Tool tool)
        {
            foreach (var toolList in tools)
            {
                try
                {
                    toolList.Remove(tool);
                    Destroy(item.gameObject);
                    return;
                }
                catch (Exception e)
                {
                }
            }
        }

        List<ItemState> itemStateListWhereDelete = new List<ItemState>();
        ItemState itemStateForDelete = null;

        for (int i = 0; i < items.Count; i++)
        {
            for (int j = 0; j < items[i].Count; j++)
            {
                if (item.image == items[i][j].item.image)
                {
                    items[i][j].count--;
        
                    if (items[i][j].count == 0)
                    {
                        items[i].Remove(items[i][j]);
                        break;
                    }
                }
            }
        }

        Destroy(item.gameObject);
    }

    public void ExpandInventory()
    {
        items.Add(new List<ItemState>());
        tools.Add(new List<Tool>());

        maxPages++;
    }
    
    private ItemState FindItemState(Item item)
    {
        foreach (var listItems in items)
        {
            foreach (var itemList in listItems)
            {
                if (itemList.item.image == item.image)
                {
                    return itemList;
                }
            }
        }

        return null; //TODO выкидывать ошибку
    }

    public List<List<ItemState>> GetItems()
    {
        return items;
    }

    public List<List<Tool>> GetTools()
    {
        return tools;
    }
}
