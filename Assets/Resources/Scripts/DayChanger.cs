using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CartSpawner))]
public class DayChanger : MonoBehaviour
{
    private int day;

    private CartSpawner cartSpawner;

    private void Start()
    {
        cartSpawner = GetComponent<CartSpawner>();
        cartSpawner.Init();
    }

    public void ChangeDay()
    {
        day++;
        
        Cart cart = cartSpawner.TrySpawn();

        if (cart == null)
        {
            Debug.Log("Утонула");
            return;
        }
        
        Debug.Log(cart.items[0]);
    }
}
