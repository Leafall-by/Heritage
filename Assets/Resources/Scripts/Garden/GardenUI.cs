using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenUI : MonoBehaviour
{
    [SerializeField] private GardenCell[] cells;

    public Vegetable AddVegetable(Vegetable vegetable)
    {
        GardenCell cell = GetAvaialableCell();
        return cell.SetVegetable(vegetable);
    }
    
    private GardenCell GetAvaialableCell()
    {
        foreach (var cell in cells)
        {
            if (cell.IsAvaialble())
            {
                return cell;
            }
        }

        return null;
    }
}
