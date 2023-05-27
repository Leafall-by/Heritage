using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public ItemState item;
    
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Image image;

    public bool IsAvailable()
    {
        return item == null;
    }

    public void SetItem(ItemState item)
    {
        if (IsAvailable() == false)
        {
            return;
        }

        this.item = item;

        image.enabled = true;
        
        SetFields(item.item.image);
    }

    private void SetFields(Sprite sprite)
    {
        text.text = item.count.ToString();
        image.sprite = sprite;
    }

    public void DeleteItem()
    {
        item = null;
        
        text.text = "";
        image.enabled = false;
    }
}
