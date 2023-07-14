using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaterUI : MonoBehaviour
{
    [SerializeField] private PlayerStats stats;
    [SerializeField] private TextMeshProUGUI textCount;
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        stats.PlayerWater.WaterIsChanged += ChangeFoodSlider;
    }

    private void ChangeFoodSlider(int water)
    {
        slider.value = water;
        textCount.text = water.ToString();
    }
}
