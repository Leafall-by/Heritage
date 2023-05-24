using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerFood))]
public class Player : MonoBehaviour
{
    public PlayerFood PlayerFood { get; private set; }

    private void Awake()
    {
        PlayerFood = GetComponent<PlayerFood>();
    }
}
