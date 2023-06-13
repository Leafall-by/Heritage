using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenController : MonoBehaviour
{
    private List<Vegetable> vegetables;
    [SerializeField] private GardenUI gardenUI;

    private void Start()
    {
        vegetables = new List<Vegetable>();
    }

    public void AddVegetable(Vegetable vegetable)
    {
        vegetables.Add(gardenUI.AddVegetable(vegetable));
    }

    public void Grow()
    {
        foreach (var vegetable in vegetables)
        {
            vegetable.AddPercent();
        }
    }
}
