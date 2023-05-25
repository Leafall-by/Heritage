using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    private const int COUNT_ITEMS_FOR_SELL = 3;
    
    public Item[] items = new Item[COUNT_ITEMS_FOR_SELL];

    public void SetItems(Item[] items)
    {
        this.items = items;
    }
}
