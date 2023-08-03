using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaterUI : MonoBehaviour
{
    [SerializeField] private PlayerStats stats;
    [SerializeField] private TextMeshProUGUI textCount;
    [SerializeField] private Image image;

    private void Start()
    {
        stats.PlayerWater.WaterIsChanged += ChangeFoodSlider;
    }

    private void ChangeFoodSlider(int water)
    {
        image.fillAmount = (float)water / PlayerWater.MAX_WATER;
        textCount.text = water.ToString();
    }
}
