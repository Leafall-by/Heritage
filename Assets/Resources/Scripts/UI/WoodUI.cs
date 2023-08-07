using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WoodUI : MonoBehaviour
{
    [SerializeField] private PlayerStats stats;
    [SerializeField] private TextMeshProUGUI textCount;
    [SerializeField] private Image image;

    private void Start()
    {
        stats.PlayerWood.WoodIsChanged += ChangeFoodSlider;
    }

    private void ChangeFoodSlider(int wood)
    {
        image.fillAmount = (float)wood / PlayerWood.MAX_WOOD;
        textCount.text = wood.ToString();
    }
}
