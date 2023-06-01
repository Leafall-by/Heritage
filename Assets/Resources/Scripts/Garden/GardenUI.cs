using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenUI : MonoBehaviour
{
    [SerializeField] private GardenCell[] cells;
    [SerializeField] private Cabbage prefab;

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            AddVegetable(prefab);
        }
    }

    public void AddVegetable(Vegetable vegetable)
    {
        GardenCell cell = GetAvaialableCell();
        cell.SetVegetable(vegetable);
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
