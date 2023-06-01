using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolCell : MonoBehaviour
{
    private Tool item;
    
    [SerializeField] private Image image;
    [SerializeField] private Image enduranceBar;

    public bool IsAvailable()
    {
        return item == null;
    }
    
    public void SetItem(Tool item)
    {
        if (IsAvailable() == false)
        {
            return;
        }

        this.item = item;

        image.enabled = true;
        enduranceBar.enabled = true;
        
        enduranceBar.fillAmount = item.endurance / 100.0f;
        
        SetFields();
    }

    private void SetFields()
    {
        image.sprite = item.image;
    }

    public void DeleteItem()
    {
        item = null;
        
        image.enabled = false;
        enduranceBar.enabled = false;
    }
}
