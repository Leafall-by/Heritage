using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class Inventory
{
    private Item[,] items;

    private int inventoryWidth = 1;
    private int inventoryHeight = 1;

    public Inventory()
    {
        items = new Item[inventoryWidth, inventoryHeight];
    }

    public void AddItem(Item item, int indexWidth, int indexHeight)
    {
        items[indexWidth, indexHeight] = item;
    }
}
