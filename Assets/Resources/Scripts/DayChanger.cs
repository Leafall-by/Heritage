using System;
using System.Collections;
using System.Collections.Generic;
using Resources.Scripts.Animation;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CartSpawner))]
public class DayChanger : MonoBehaviour
{
    private int day;

    private CartSpawner cartSpawner;

    private Cart cart;

    [SerializeField] private ShopController shopController;
    [SerializeField] private GardenController gardenController;
    [SerializeField] private CardGiverUI cardGiverUI;
    
    //TODO: Вынести в отдельный класс
    [SerializeField] private ChangeDayAnimation dayAnimation;
    [SerializeField] private TextMeshProUGUI dayGUI;
    [SerializeField] private GameObject _spawnPoint;

    public UnityEvent DayChanged;
    private void Start()
    {
        cartSpawner = GetComponent<CartSpawner>();
        cartSpawner.Init();
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
        gardenController.Grow();
        dayGUI.text = $"День: {day}";
        dayAnimation.ChangeDay();
        
        DayChanged?.Invoke();
    }
    
    //Спавн карт в анимации.
    public void ShowCards()
    {
        cardGiverUI.ShowCanvas();
        cardGiverUI.RandomizeCards();
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
