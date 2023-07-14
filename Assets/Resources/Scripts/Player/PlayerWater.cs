using System;
using UnityEngine;

public class PlayerWater : MonoBehaviour
{
    public int Water { get; private set; }
    private const int MAX_WATER = 50;
    
    public Action<int> WaterIsChanged;
    
    public void AddWater(int water)
    {
        this.Water += water;

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
