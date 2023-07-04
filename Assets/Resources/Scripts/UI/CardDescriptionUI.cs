using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDescriptionUI : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private TextMeshProUGUI fullDescription;
    [SerializeField] private TextMeshProUGUI smallDescription;

    public void EnableDescriptionUI(Card card)
    {
        image.sprite = card.BaseSprite;
        fullDescription.text = card.fullDesc;
        smallDescription.text = card.description.text;
        name.text = card.name.text;
        
        this.gameObject.SetActive(true);
    }

    public void CloseUI()
    {
        this.gameObject.SetActive(false);
    }
}
