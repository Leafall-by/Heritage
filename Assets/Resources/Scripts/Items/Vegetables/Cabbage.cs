using UnityEngine;
using UnityEngine.UI;

public class Cabbage : Vegetable
{
    [SerializeField] private Sprite[] sprites;
    
    public override void AddPercent()
    {
        GrowPercent += Random.Range(5, 15);
        if (GrowPercent > 20)
        {
            GetComponent<Image>().sprite = sprites[1];
        }
        if (GrowPercent > 40)
        {
            GetComponent<Image>().sprite = sprites[2];
        }
        if (GrowPercent > 70)
        {
            GetComponent<Image>().sprite = sprites[3]; 
        }
        if (GrowPercent == 100)
        {
            GetComponent<Image>().sprite = sprites[4];
        }
    }
}
