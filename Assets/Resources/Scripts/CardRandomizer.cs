using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CardRandomizer
{

    private Card[] allCards;
    
    private int cardCount = 3;
    
    private Card[] randomizedCards;

    public CardRandomizer(Card[] cards)
    {
        allCards = cards;
    }
    
    public Card[] Randomize()
    {
        randomizedCards = new Card[cardCount];
        
        for (int i = 0; i < cardCount; i++)
        {
            randomizedCards[i] = GetRandomCard();
        }

        return randomizedCards;
    }

    private Card GetRandomCard()
    {
        Card randomCard = allCards[Random.Range(0, allCards.Length)];

        bool isContains = false;
        foreach (var card in randomizedCards)
        {
            if (card == randomCard)
            {
                isContains = true;
            }
        }

        if (isContains == false)
        {
            return randomCard;
        }

        return GetRandomCard();
    }
    
}
