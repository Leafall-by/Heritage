using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardGiverUI : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private CardUI cardUI;
    [SerializeField] private CardDescriptionUI descUI;
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
        SubscribeCard(card);

        if (card.prefabCard is TimeCard tc)
        {
            cardUI.AddCard(tc);  
        }
        else card.prefabCard.Use();
    }

    private void ShowBlindCard()
    {
        if (randomizedCards[currentCardIndex].prefabCard is Blind)
        {
            CardContainer card = Instantiate(randomizedCards[currentCardIndex], spawnpoints[currentCardIndex].transform);
            currentCardIndex++;
            
            cardUI.AddCard((TimeCard)card.prefabCard);
            SubscribeCard(card);

            return;
        }
        
        CardContainer blindCard = Instantiate(blindCardContainer, spawnpoints[currentCardIndex].transform);
        blindCard.prefabCard = randomizedCards[currentCardIndex].prefabCard;
        currentCardIndex++;
        SubscribeCard(blindCard);

        if (blindCard.prefabCard is TimeCard tc)
        {
            cardUI.AddCard(tc);   
        }
        else blindCard.prefabCard.Use();
    }

    private void SubscribeCard(CardContainer card)
    {
        card.OnClick.AddListener(OpenDescriptionUI);
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

    private void OpenDescriptionUI(CardContainer card)
    {
        if (card is BlackContainer)
        {
            return;
        }
        descUI.EnableDescriptionUI(card.prefabCard);
    }
}
