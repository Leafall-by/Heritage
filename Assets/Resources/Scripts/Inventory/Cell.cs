using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Cell : MonoBehaviour, IPointerClickHandler
{
    public Action<Item> OnUsed;
    
    [SerializeField] private Image image;
    [SerializeField] private Image shadowImage;
    [SerializeField] private TextMeshProUGUI text;
    
    private ItemState item;

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
        shadowImage.enabled = true;
        
        SetFields();
    }

    private void SetFields()
    {
        text.text = item.count.ToString();
        image.sprite = item.item.image;
    }

    public void DeleteItem()
    {
        item = null;
        
        text.text = "";
        image.enabled = false;
        shadowImage.enabled = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnUsed?.Invoke(item.item);
    }
}
