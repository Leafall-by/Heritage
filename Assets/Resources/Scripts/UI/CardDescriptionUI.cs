using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class CardDescriptionUI : MonoBehaviour
{
    [SerializeField] private GameObject SpawnPoint;
    [SerializeField] private TextMeshProUGUI description;

    private Card card;

    public void EnableDescriptionUI(Card card)
    {
        this.card = Instantiate(card, SpawnPoint.transform);

        SettingRectTransform(this.card);

        description.text = LocalizationSettings.StringDatabase.GetLocalizedString("CardFullDesc", card.fullDescKey);

        this.gameObject.SetActive(true);
    }

    private void SettingRectTransform(Card card)
    {
        RectTransform transform = this.card.transform as RectTransform;
        transform.anchorMin = new Vector2(0.5f, 0.5f);
        transform.anchorMax = new Vector2(0.5f, 0.5f);
        transform.pivot = new Vector2(0.5f, 0.5f);
        transform.sizeDelta = new Vector2(387, 382);
        card.transform.localScale = new Vector3(1.7f, 1.7f, 1f);
    }

    public void CloseUI()
    {
        Destroy(card.gameObject);
        this.gameObject.SetActive(false);
    }
}
