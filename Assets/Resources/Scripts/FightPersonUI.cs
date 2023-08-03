using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FightPersonUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image image;
    [SerializeField] private MeshRenderer material;

    private FightPerson fightPerson;

    [HideInInspector] public UnityEvent<FightPerson> OnClick;

    public void SetPerson(FightPerson fightPerson)
    {
        image.enabled = true;
        this.fightPerson = fightPerson;
        image.sprite = fightPerson.sprite;
    }

    public void SetBorder()
    {
        material.material.SetColor("_Color", Color.red);
        image.material = material.material;
    }

    public void DestroyBorder()
    {
        image.material = null;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick?.Invoke(fightPerson);
    }

    public bool IsAvaialable()
    {
        return fightPerson == null;
    }
}
