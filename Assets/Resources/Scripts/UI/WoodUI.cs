using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WoodUI : MonoBehaviour
{
    [SerializeField] private PlayerStats stats;
    [SerializeField] private TextMeshProUGUI textCount;
    private Slider slider;
    
    private void Start()
    {
        slider = GetComponent<Slider>();
        stats.PlayerWood.WoodIsChanged += ChangeFoodSlider;
    }

    private void ChangeFoodSlider(int wood)
    { 
        slider.value = wood;
        textCount.text = wood.ToString();
    }
}
