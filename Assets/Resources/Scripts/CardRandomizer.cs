using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CardRandomizer
{
    private CardContainer[] allCards;
    
    private int cardCount = 3;
    
    private CardContainer[] randomizedCards;

    public CardRandomizer(CardContainer[] cards)
    {
        allCards = cards;
    }
    
    public CardContainer[] Randomize()
    {
        randomizedCards = new CardContainer[cardCount];
        
        for (int i = 0; i < cardCount; i++)
        {
            randomizedCards[i] = GetRandomCard();
        }

        return randomizedCards;
    }

    private CardContainer GetRandomCard()
    {
        CardContainer randomCard = allCards[Random.Range(0, allCards.Length)];

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
