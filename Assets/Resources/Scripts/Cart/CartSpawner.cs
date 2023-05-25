using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartSpawner : MonoBehaviour
{
    [SerializeField] private Item[] items;
    [SerializeField] private Cart cart;
    
    private CartRandomizer randomizer;

    public void Init()
    {
        randomizer = new CartRandomizer(items, cart);
    }

    public Cart TrySpawn()
    {
        if (randomizer.IsSpawn())
        {
            Debug.Log("Телега приехала");
            return randomizer.GetCart();
        }
        else return null; //TODO Ошибку, если телега не приехала
    }
}
