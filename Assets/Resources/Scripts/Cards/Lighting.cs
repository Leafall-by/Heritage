using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting : Card, IDependet
{
    [SerializeField] private int woodForMinus;
    [SerializeField] private int waterForMinus;
    
    public override void Use()
    {
        Weather weather = FindObjectOfType<Weather>();

        if (weather.IsRain == true)
        {
            PlayerStats stats = FindObjectOfType<PlayerStats>();
            stats.PlayerWood.RemoveWood(woodForMinus);
            stats.PlayerWater.RemoveWater(waterForMinus);
        }
    }

    public bool IsCan()
    {
        return FindObjectOfType<Weather>().IsRain;
    }
}
