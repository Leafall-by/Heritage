using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : Card
{
    [SerializeField] private int woodForMinus;
    [SerializeField] private int waterForMinus;
    
    public override void Use()
    {
        Debug.Log("House");
        Weather weather = FindObjectOfType<Weather>();

        if (weather.IsRain == true)
        {
            PlayerStats stats = FindObjectOfType<PlayerStats>();
            stats.PlayerWood.RemoveWood(woodForMinus);
            stats.PlayerWater.RemoveWater(waterForMinus);
        }
    }
}
