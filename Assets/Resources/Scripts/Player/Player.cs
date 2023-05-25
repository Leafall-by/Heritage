using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerFood), typeof(Wallet))]
public class Player : MonoBehaviour
{
    public PlayerFood PlayerFood { get; private set; }
    public Wallet Wallet { get; private set; }

    private void Awake()
    {
        PlayerFood = GetComponent<PlayerFood>();
        Wallet = GetComponent<Wallet>();
    }
}
