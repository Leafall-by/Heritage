using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ItemData
{
    public List<int> idItems;

    public int maxPage;

    public ItemData()
    {
        idItems = new List<int>();
    }
}
