using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardUI : MonoBehaviour
{
    public UnityEvent<Card> CardAdded;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject content;
    private List<Card> cards = new List<Card>();
    
    
    public void AddCard(Card cardPrefab)
    {
        Card card = Instantiate(cardPrefab, content.transform);
        cards.Add(card); 
        CardAdded?.Invoke(card);
    }

    public void DeleteCard(Card card)
    {
        cards.Remove(card);
        Destroy(card.gameObject);
    }
    
    public void ShowCards()
    {
        canvas.SetActive(true);
    }

    public void CloseCanvas()
    {
        canvas.SetActive(false);
    }

    public void HideCard(Card card)
    {
        card.HideCard();
    }

    public void EnableCards()
    {
        foreach (var card in cards)
        {
            card.ShowCard();
        }
    }

    public List<Card> GetCards()
    {
        return cards;
    }
}
