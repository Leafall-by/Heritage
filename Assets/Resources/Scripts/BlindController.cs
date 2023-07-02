using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BlindController : MonoBehaviour
{
    [SerializeField] private Image blackCard;
    [SerializeField] private CardUI cardUI;
    [SerializeField] private CardGiverUI cardGiver;
    [SerializeField] private DayChanger dayChanger;
    private int dayDuration;
    private Card activedCard;

    private void Start()
    {
        dayChanger.DayChanged.AddListener(DecreaseDuration); 
        cardUI.CardAdded.AddListener(HideCardInInventory);
    }

    public void StartBlind(Blind card)
    {
        activedCard = card;
        cardGiver.IsBlind = true;
        dayDuration = card.DayDuration;
        HideCardsInInventory();
    }

    private void HideCardsInInventory()
    {
        foreach (var card in cardUI.GetCards())
        {
            cardUI.HideCard(card);   
        }
    }

    private void HideCardInInventory(Card card)
    {
        if (activedCard == null || card is Blind)
        {
            return;
        }
        
        cardUI.HideCard(card);
    }

    public void ShowCardInInventory()
    {
        cardUI.EnableCards();
    }

    private void DecreaseDuration()
    {
        dayDuration--;

        if (dayDuration == 0)
        {
            StopBlind();
        }
    }

    private void StopBlind()
    {
        activedCard = null;
        cardGiver.IsBlind = false;
        ShowCardInInventory();
    }
}
