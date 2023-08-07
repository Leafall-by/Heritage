using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class CardDescriptionUI : MonoBehaviour
{
    [SerializeField] private Image cardImage;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI fullDescription;

    private Card card;

    public void EnableDescriptionUI(Card card)
    {
        cardImage.sprite = card.BaseSprite;

        titleText.text = card.name.gameObject.GetComponent<LocalizeStringEvent>().StringReference.GetLocalizedString();
        descriptionText.text = card.description.gameObject.GetComponent<LocalizeStringEvent>().StringReference.GetLocalizedString();
        fullDescription.text = LocalizationSettings.StringDatabase.GetLocalizedString("CardFullDesc", card.fullDescKey);

        this.gameObject.SetActive(true);
    }

    public void CloseUI()
    {
        this.gameObject.SetActive(false);
    }
}
