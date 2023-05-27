using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private GameObject deathCanvas;
    
    [SerializeField] private PlayerStats playerStats;

    private void Start()
    {
        playerStats.PlayerFood.FoodChanged += TryDie;
        playerStats.PlayerWater.WaterIsChanged += TryDie;
        playerStats.PlayerWood.WoodIsChanged += TryDie;
    }

    private void TryDie(int resource)
    {
        if (resource < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        deathCanvas.SetActive(true);
    }
}
