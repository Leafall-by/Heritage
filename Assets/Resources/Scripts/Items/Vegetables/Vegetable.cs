using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Vegetable : Food
{
    private int growPercent;
    public int GrowPercent
    {
        get => growPercent;
        set
        {
            growPercent += value;
            if (growPercent > 100)
            {
                growPercent = 100;
            }
        }
    }

    public abstract void AddPercent();
}
