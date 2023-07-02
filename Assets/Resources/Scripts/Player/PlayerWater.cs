using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWater : MonoBehaviour
{
    public int water { get; private set; }

    public Action<int> WaterIsChanged;
    
    public void AddWater(int water)
    {
        this.water += water;
        WaterIsChanged?.Invoke(this.water);
        
        Debug.Log($"Вода: {this.water}");
    }

    public void RemoveWater(int water)
    {
        this.water -= water;
        WaterIsChanged?.Invoke(this.water);
        
        Debug.Log($"Вода: {this.water}");
    }
}
