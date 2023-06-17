using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardUI : MonoBehaviour
{
    [SerializeField] private Card[] allCards;
    [SerializeField] private GameObject canvas;

    private List<Card> cards = new List<Card>();

    public void AddCard(Card card)
    {
        cards.Add(card);
    }
    
    public void ShowCards()
    {
        canvas.SetActive(true);

        CardRandomizer randomizer = new CardRandomizer(allCards);
        Card[] cards = randomizer.Randomize();
        foreach (var card in cards)
        {
            Debug.Log(card);
            AddCard(card);
        }
    }

    public void CloseCanvas()
    {
        canvas.SetActive(false);
    }
}
