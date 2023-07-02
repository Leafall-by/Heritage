using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private GameObject deathCanvas;
    [SerializeField] private DayChanger dayChanger;
    
    [SerializeField] private PlayerStats playerStats;

    private void Start()
    {
        dayChanger.DayChanged.AddListener(TryDie);
    }

    private void TryDie()
    {
        if (playerStats.PlayerWater.water < 0 || playerStats.PlayerFood.Food < 0 || playerStats.PlayerWood.wood < 0)
        {
            Die();
        }
    }

    private void Die()
    { 
        deathCanvas.SetActive(true);
    }
}
