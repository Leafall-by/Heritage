using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class CardUI : MonoBehaviour
{
    public UnityEvent<TimeCard> CardAdded;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject content;
    [SerializeField] private DayChanger changer;
    private List<TimeCard> cards = new List<TimeCard>();

    private void Start()
    {
        changer.DayChanged.AddListener(DecreaseDay);
    }

    public void AddCard(TimeCard cardPrefab)
    {
        TimeCard sameCard = cards.FirstOrDefault(x => x.GetType() == cardPrefab.GetType());
        if ( sameCard != null)
        {
            DeleteCard(sameCard);
        }
        
        TimeCard card = Instantiate(cardPrefab, content.transform);
        cards.Add(card);
        card.Use();
        CardAdded?.Invoke(card);
    }

    private void DecreaseDay()
    {
        List<TimeCard> cardForDelete = new List<TimeCard>();
        foreach (var card in cards)
        {
            card.DecreaseDuration();

            if (card.dayDuration <= 0)
            {
                cardForDelete.Add(card);
            }
        }

        foreach (var deleteCard in cardForDelete)
        {
            DeleteCard(deleteCard);
        }
    }

    public void DeleteCard(TimeCard card)
    {
        cards.Remove(card);
        Destroy(card.gameObject);
    }
    
    public void ShowCards()
    {
        canvas.SetActive(true);
    }

    public void CloseCanvas()
    {
        canvas.SetActive(false);
    }

    public void HideCard(TimeCard card)
    {
        card.HideCard();
    }

    public void EnableCards()
    {
        foreach (var card in cards)
        {
            card.ShowCard();
        }
    }

    public List<TimeCard> GetCards()
    {
        return cards;
    }
}
