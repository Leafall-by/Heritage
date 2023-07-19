using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CartData
{
    public bool isSpawn;
    
    public List<int> idItems;

    public CartData()
    {
        idItems = new List<int>();
    }
}
