using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Card
{
    public override void Use()
    {
        Debug.Log("Wolf");
        PlayerStats stats = FindObjectOfType<PlayerStats>();
        PlayerFood food = stats.PlayerFood;

        if (food.Food <= 0)
        {
            //TODO Player's death
        }
        food.RemoveFood(food.Food);
    }
}
