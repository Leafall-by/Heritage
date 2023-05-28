using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartSpawner : MonoBehaviour
{
    [SerializeField] private Item[] items;
    [SerializeField] private Cart cart;
    [SerializeField] private GameObject _spawnPoint;
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
            Cart cart = Instantiate(randomizer.GetCart(), _spawnPoint.transform);
            return cart;
        }
        else return null; //TODO Ошибку, если телега не приехала
    }
}
