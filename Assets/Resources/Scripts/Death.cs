using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private GameObject deathCanvas;
    
    [SerializeField] private PlayerFood foodHandler;

    private void Start()
    {
        foodHandler.FoodChanged += TryDie;
    }

    private void TryDie(int food)
    {
        if (food < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        deathCanvas.SetActive(true);
    }
}
