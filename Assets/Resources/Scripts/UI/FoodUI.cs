using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FoodUI : MonoBehaviour
{
    [SerializeField] private PlayerStats stats;
    [SerializeField] private TextMeshProUGUI textCount;
    [SerializeField] private Image image;

    private void Start()
    {
        stats.PlayerFood.FoodIsChanged += ChangeFoodSlider;
    }

    private void ChangeFoodSlider(int food)
    {
        image.fillAmount = (float)food / PlayerFood.MAX_FOOD;
        textCount.text = food.ToString();
    }
}
