using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGiverUI : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private CardUI cardUI;
    [Space]
    [SerializeField] private CardContainer[] allCardContainer;
    [SerializeField] private Transform[] spawnpoints;

    private int currentCardIndex;

    private CardContainer[] randomizedCards;

    public void RandomizeCards()
    {
        currentCardIndex = 0;
        CardRandomizer randomizer = new CardRandomizer(allCardContainer);
        randomizedCards = randomizer.Randomize();
    }
    
    public void ShowCard()
    {
        CardContainer card = Instantiate(randomizedCards[currentCardIndex], spawnpoints[currentCardIndex].transform);
        currentCardIndex++;
        
        card.prefabCard.Use();
        cardUI.AddCard(card.prefabCard);
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
