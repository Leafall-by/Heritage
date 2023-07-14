using System;
using System.Collections.Generic;
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
        List<CardContainer> availableCards = new List<CardContainer>();
        
        int sum = 0;
        foreach (var card in allCards)
        {
            if ((card.prefabCard is IDependet dependet && !dependet.IsCan()) || IsContains(card))
            {
                continue;
            }
            sum += card.prefabCard.dropChance;
            availableCards.Add(card);
        }
        
        int random = Random.Range(0, sum);
        for (int i = 0; i < availableCards.Count; i++)
        {
            random -= availableCards[i].prefabCard.dropChance;
            if (random <= 0)
            {
                return availableCards[i];
            }
        }

        throw new NullReferenceException();
    }

    private bool IsContains(CardContainer randomCard)
    {
        bool isContains = false;
        foreach (var card in randomizedCards)
        {
            if (card == randomCard)
            {
                isContains = true;
            }
        }

        return isContains;
    }
    
}
