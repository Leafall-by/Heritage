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

    private Cart cart;

    [SerializeField] private ShopController shopController;

    private void Start()
    {
        cartSpawner = GetComponent<CartSpawner>();
        cartSpawner.Init();
        
        shopController.Init();
    }

    public void ChangeDay()
    {
        try
        {
            Destroy(cart.gameObject);
        }
        catch (NullReferenceException e)
        {
        }

        day++;
        
        cart = cartSpawner.TrySpawn();
        if (cart == null)
        {
            return;
        }
        
        cart.SetShopController(shopController);
    }
}
