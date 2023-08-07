using System;
using UnityEngine;

public class PlayerWater : MonoBehaviour
{
    public int Water { get; private set; }
    public const int MAX_WATER = 50;
    
    [HideInInspector] public Action<int> WaterIsChanged;

    private int multiplier = 1;

    public void AddWater(int water)
    {
        this.Water += water * multiplier;

        if (Water > MAX_WATER)
        {
            Water = MAX_WATER;
        }
        
        WaterIsChanged?.Invoke(this.Water);
    }

    public void RemoveWater(int water)
    {
        this.Water -= water;
        WaterIsChanged?.Invoke(this.Water);
    }
}
