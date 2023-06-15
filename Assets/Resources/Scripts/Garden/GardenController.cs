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
        gardenUI.OnCollect += DeleteVegetable;
    }

    public void AddVegetable(Vegetable vegetable)
    {
        Vegetable objVegetable = gardenUI.AddVegetable(vegetable);
        vegetables.Add(objVegetable);
    }

    public void Grow()
    {
        foreach (var vegetable in vegetables)
        {
            vegetable.AddPercent();
        }
    }

    public bool IsAvaiable()
    {
        return gardenUI.IsAvaiable();
    }

    private void DeleteVegetable(Vegetable vegetable)
    {
        Inventory inventory = FindObjectOfType<Player>().Inventory;
        inventory.AddItem(vegetable);
        vegetables.Remove(vegetable);
        Destroy(vegetable.gameObject);
    }
}
