using System;
using System.Collections;
using System.Collections.Generic;
using Resources.Scripts.Animation;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CartSpawner))]
public class DayChanger : MonoBehaviour
{
    private int day;

    private CartSpawner cartSpawner;

    private Cart cart;

    [SerializeField] private ShopController shopController;
    
    //TODO: Вынести в отдельный класс
    [SerializeField] private ChangeDayAnimation dayAnimation;
    [SerializeField] private TextMeshProUGUI dayGUI;
    [SerializeField] private GameObject _spawnPoint;
    private void Start()
    {
        cartSpawner = GetComponent<CartSpawner>();
        cartSpawner.Init();
        
        shopController.Init();
    }

    public void DeleteCart()
    {
        if (cart == null)
        {
            return;
        }
        
        Destroy(cart.gameObject);
    }

    public void ChangeDay()
    {
        day++;
        
        dayGUI.text = $"День: {day}";
        dayAnimation.ChangeDay();
    }

    //Лошадь спавнится в анимации
    public void SpawnCart()
    {
        cart = cartSpawner.TrySpawn();
        if (cart == null)
        {
            return;
        }
        cart.SetShopController(shopController);
    }
        
}
