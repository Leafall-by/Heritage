using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CardContainer : MonoBehaviour, IPointerClickHandler
{
    public Card prefabCard;
    [SerializeField] private AudioSource _audio;
    public UnityEvent<CardContainer> OnClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        _audio.Play();
        OnClick.Invoke(this);
    }
}
