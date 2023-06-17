using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardUI : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject content;
    private List<Card> cards = new List<Card>();

    public void AddCard(Card cardPrefab)
    {
        cards.Add(Instantiate(cardPrefab, content.transform)); 
    }
    
    public void ShowCards()
    {
        canvas.SetActive(true);
    }

    public void CloseCanvas()
    {
        canvas.SetActive(false);
    }
}
