using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Card : MonoBehaviour
{
    [SerializeField] private string cardName;
    [SerializeField] private string cardDescrtiption;
    
    public Sprite BlackCardSprite;
    public Sprite BaseSprite;
    
    public TextMeshProUGUI name;
    public TextMeshProUGUI description;

    public void HideCard()
    {
        name.text = "";
        description.text = "";
        gameObject.GetComponent<Image>().sprite = BlackCardSprite;
    }
    
    public void ShowCard()
    {
        name.text = cardName;
        description.text = cardDescrtiption;
        gameObject.GetComponent<Image>().sprite = BaseSprite;
    }

    abstract public void Use();
}
