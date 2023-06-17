using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGiverUI : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private CardUI cardUI;
    [Space]
    [SerializeField] private Card[] allCards;
    [SerializeField] private Transform[] spawnpoints;

    private int currentCardIndex;

    private Card[] randomizedCards;

    public void RandomizeCards()
    {
        currentCardIndex = 0;
        CardRandomizer randomizer = new CardRandomizer(allCards);
        randomizedCards = randomizer.Randomize();
    }
    
    public void ShowCard()
    {
        Card card = Instantiate(randomizedCards[currentCardIndex], spawnpoints[currentCardIndex].transform);
        currentCardIndex++;
        
        cardUI.AddCard(card);
    }

    public void ShowCanvas()
    {
        canvas.gameObject.SetActive(true);
    }

    public void CloseCanvas()
    {
        canvas.gameObject.SetActive(false);
    }
}
