using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenUI : MonoBehaviour
{
    public Action<Vegetable> OnCollect;
    
    [SerializeField] private GardenCell[] cells;

    private void Start()
    {
        foreach (var cell in cells)
        {
            cell.OnCollect += CollectVegetable;
        }
    }

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

    public bool IsAvaiable()
    {
        foreach (var cell in cells)
        {
            if (cell.IsAvaialble() == false)
            {
                return false;
            }
        }

        return true;
    }

    private void CollectVegetable(Vegetable vegetable)
    {
        OnCollect?.Invoke(vegetable);
    }
}
