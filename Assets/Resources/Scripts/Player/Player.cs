using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerStats), typeof(Wallet))]
public class Player : MonoBehaviour
{
    public PlayerStats PlayerStats { get; private set; }
    public Wallet Wallet { get; private set; }
    
    public Inventory Inventory { get; private set; }

    private void Awake()
    {
        PlayerStats = GetComponent<PlayerStats>();
        PlayerStats.Init();

        Wallet = GetComponent<Wallet>();

        Inventory = new Inventory();
    }
}
