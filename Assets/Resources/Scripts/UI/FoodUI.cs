using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FoodUI : MonoBehaviour
{
    [SerializeField] private PlayerStats stats;
    [SerializeField] private TextMeshProUGUI textCount;
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        stats.PlayerFood.FoodIsChanged += ChangeFoodSlider;
    }

    private void ChangeFoodSlider(int food)
    {
        slider.value = food;
        textCount.text = food.ToString();
    }
}
