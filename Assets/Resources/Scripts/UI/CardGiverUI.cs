using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardGiverUI : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private CardUI cardUI;
    [Space]
    [SerializeField] private CardContainer[] allCardContainer;
    [SerializeField] private CardContainer blindCardContainer;
    [SerializeField] private Transform[] spawnpoints;

    private int currentCardIndex;

    private CardContainer[] randomizedCards;

    public bool IsBlind { get; set; } = false;

    public void RandomizeCards()
    {
        currentCardIndex = 0;
        CardRandomizer randomizer = new CardRandomizer(allCardContainer);
        randomizedCards = randomizer.Randomize();
    }
    
    public void ShowCard()
    {
        if (IsBlind)
        {
            ShowBlindCard();
            return;
        }
        
        CardContainer card = Instantiate(randomizedCards[currentCardIndex], spawnpoints[currentCardIndex].transform);
        currentCardIndex++;
        
        card.prefabCard.Use();
        cardUI.AddCard(card.prefabCard);
    }

    private void ShowBlindCard()
    {
        if (randomizedCards[currentCardIndex].prefabCard is Blind)
        {
            CardContainer card = Instantiate(randomizedCards[currentCardIndex], spawnpoints[currentCardIndex].transform);
            currentCardIndex++;
        
            card.prefabCard.Use();
            cardUI.AddCard(card.prefabCard);
            return;
        }
        
        CardContainer blindCard = Instantiate(blindCardContainer, spawnpoints[currentCardIndex].transform);
        blindCard.prefabCard = randomizedCards[currentCardIndex].prefabCard;
        currentCardIndex++;
        
        blindCard.prefabCard.Use();
        cardUI.AddCard(blindCard.prefabCard);
    }

    public void ShowCanvas()
    {
        canvas.gameObject.SetActive(true);
    }

    public void CloseCanvas()
    {
        canvas.gameObject.SetActive(false);

        foreach (var spawnpoint in spawnpoints)
        {
            Destroy(spawnpoint.GetChild(0).gameObject);
        }
    }
}
