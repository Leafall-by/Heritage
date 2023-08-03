using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Localization.Settings;

public class CardContainer : MonoBehaviour, IPointerClickHandler
{
    public Card prefabCard;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private TextMeshProUGUI desc;
    [HideInInspector] public UnityEvent<CardContainer> OnClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        _audio.Play();
        OnClick.Invoke(this);
    }

    public void ChangeDescWithKey(string key)
    {
        desc.text = LocalizationSettings.StringDatabase.GetLocalizedString("CardDesc", key);
    }
}
