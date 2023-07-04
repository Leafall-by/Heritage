using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CardContainer : MonoBehaviour, IPointerClickHandler
{
    public Card prefabCard;

    public UnityEvent<CardContainer> OnClick;
    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick.Invoke(this);
    }
}
