using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

abstract public class Seed : Item
{
    [SerializeField] private Vegetable prefab;
    [SerializeField] private int seedCount;

    public override void Use()
    {
        GardenController controller = FindObjectOfType<GardenController>();

        for (int i = 0; i < seedCount; i++)
        {
            controller.AddVegetable(prefab);
        }
    }
}
