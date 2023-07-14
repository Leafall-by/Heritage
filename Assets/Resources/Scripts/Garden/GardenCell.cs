using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class GardenCell : MonoBehaviour, IPointerClickHandler
{
    public Action<Vegetable> OnCollect;
    
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

    public void TryDestroyVegetable()
    {
        if (vegetable.GrowPercent == 100)
        {
            OnCollect?.Invoke(vegetable);
            this.vegetable = null;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        TryDestroyVegetable();
    }
}
