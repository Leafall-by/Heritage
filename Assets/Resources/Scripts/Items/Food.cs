using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : Item
{
    [SerializeField] private int food;

    private PlayerFood playerFood;

    private void Init()
    {
        playerFood = FindObjectOfType<PlayerFood>();
    }
    
    public override void Use()
    {
        Init();
        
        playerFood.AddFood(food);
    }
}
