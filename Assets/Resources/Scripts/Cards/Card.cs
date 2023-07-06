using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class Card : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string cardName;
    [SerializeField] private string cardDescrtiption;
    public string fullDesc;
    public int dropChance;

    public Sprite BlackCardSprite;
    public Sprite BaseSprite;
    
    public TextMeshProUGUI name;
    public TextMeshProUGUI description;

    public UnityEvent<Card> OnClick;

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

    public void OnPointerClick(PointerEventData eventData)
    {
        AudioSource audio = GetComponent<AudioSource>();
        if (audio != null)
        {
            audio.Play();
        }
        OnClick?.Invoke(this);
    }
    
    abstract public void Use();

}
