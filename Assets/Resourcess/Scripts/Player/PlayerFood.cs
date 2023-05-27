using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerFood : MonoBehaviour
{
    private int food;

    public event Action<int> FoodChanged;

    public void AddFood(int food)
    {
        this.food += food;
        
        FoodChanged?.Invoke(this.food);

        Debug.Log($"Еда: {this.food}");
    }

    public void RemoveFood(int food)
    {
        this.food -= food;
            
        FoodChanged?.Invoke(this.food);
        
        Debug.Log($"Еда: {this.food}");
    }

    
}
