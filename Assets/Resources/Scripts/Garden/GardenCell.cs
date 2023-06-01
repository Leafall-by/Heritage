using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GardenCell : MonoBehaviour
{
    private Vegetable vegetable;
    [SerializeField] private Image image;

    public bool IsAvaialble()
    {
        return vegetable == null;
    }

    public void SetVegetable(Vegetable vegetable)
    {
        this.vegetable = Instantiate(vegetable, this.transform);
    }

    public void DestroyVegetable()
    {
        vegetable = null;
    }
}
