using System;
using UnityEngine;

public class PlayerFood : MonoBehaviour
{
    public int Food { get; private set; }
    public const int MAX_FOOD = 50;

    public event Action<int> FoodIsChanged;

    public void AddFood(int food)
    {
        this.Food += food;

        if (this.Food > MAX_FOOD)
        {
            this.Food = MAX_FOOD;
        }
        
        FoodIsChanged?.Invoke(this.Food);
    }

    public void RemoveFood(int food)
    {
        this.Food -= food;
            
        FoodIsChanged?.Invoke(this.Food);
    }
}
