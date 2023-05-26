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

    [SerializeField] private ShopController shopController;

    private void Start()
    {
        cartSpawner = GetComponent<CartSpawner>();
        cartSpawner.Init();
        
        shopController.Init();
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
        
        cart.SetShopController(shopController);
    }
}
