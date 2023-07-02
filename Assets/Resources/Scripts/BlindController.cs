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
    
    private Card activedCard;

    private void Start()
    {
        cardUI.CardAdded.AddListener(HideCardInInventory);
    }

    public void StartBlind(Blind card)
    {
        activedCard = card;
        cardGiver.IsBlind = true;
        HideCardsInInventory();
    }

    private void HideCardsInInventory()
    {
        foreach (var card in cardUI.GetCards())
        {
            HideCardInInventory(card);
        }
    }

    private void HideCardInInventory(TimeCard card)
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

    public void StopBlind()
    {
        activedCard = null;
        cardGiver.IsBlind = false;
        ShowCardInInventory();
    }
}
