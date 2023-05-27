using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemState
{
    public Item item;

    public int count;

    public ItemState(Item item)
    {
        this.item = item;
        count++;
    }
}
