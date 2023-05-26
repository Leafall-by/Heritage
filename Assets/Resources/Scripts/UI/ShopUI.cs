using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private GameObject[] SpawnPoint;
    [SerializeField] private Button[] buttons;

    public Action<int> ItemIsBought;

    private void ShowShop(Item[] items)
    {
        gameObject.SetActive(true);
    }

    public void SetItemsUI(Item[] items)
    {
        ShowButtons();
        
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                buttons[i].gameObject.SetActive(false);
                continue;
            }
            
            Instantiate(items[i].gameObject, SpawnPoint[i].transform);
        }
        
        ShowShop(items);
    }

    private void ShowButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(true);
        }
    }

    public void DeleteItemUI(int index)
    {
        Destroy(SpawnPoint[index].transform.GetChild(0).gameObject);
        
        buttons[index].gameObject.SetActive(false);
    }
}
