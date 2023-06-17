using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGiverUI : MonoBehaviour
{
    [SerializeField] private Card[] allCards;
    [SerializeField] private GameObject content;
    [SerializeField] private GameObject canvas;
    [SerializeField] private CardUI cardUI;

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
        Card card = Instantiate(randomizedCards[currentCardIndex], content.transform);
        currentCardIndex++;
        
        cardUI.AddCard(card);
    }

    public void ShowCanvas()
    {
        canvas.SetActive(true);
    }

    public void CloseCanvas()
    {
        canvas.SetActive(false);
    }
}
