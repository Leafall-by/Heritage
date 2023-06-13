using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GardenCell : MonoBehaviour
{
    private Vegetable vegetable;

    public bool IsAvaialble()
    {
        return vegetable == null;
    }

    public Vegetable SetVegetable(Vegetable vegetable)
    {
        this.vegetable = Instantiate(vegetable, this.transform);
        return this.vegetable;
    }

    public void DestroyVegetable()
    {
        vegetable = null;
    }
}
