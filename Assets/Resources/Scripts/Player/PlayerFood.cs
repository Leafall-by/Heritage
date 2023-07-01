using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerFood : MonoBehaviour
{
    public int Food { get; private set; }

    public event Action<int> FoodChanged;

    public void AddFood(int food)
    {
        this.Food += food;
        
        FoodChanged?.Invoke(this.Food);

        Debug.Log($"Еда: {this.Food}");
    }

    public void RemoveFood(int food)
    {
        this.Food -= food;
            
        FoodChanged?.Invoke(this.Food);
        
        Debug.Log($"Еда: {this.Food}");
    }
}
