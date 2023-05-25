using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : ActiveItem
{
    private int food;

    private PlayerFood playerFood;

    public void Init(PlayerFood playerFood)
    {
        this.playerFood = playerFood;
    }
    
    public override void Use()
    {
        playerFood.AddFood(food);
    }
}
