using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cabbage : Vegetable
{
    [SerializeField] private Sprite[] sprites;
    
    public override void AddPercent()
    {
        GrowPercent += Random.Range(10, 21);
        if (GrowPercent > 20)
        {
            GetComponent<Image>().sprite = sprites[1];
        }
        if (GrowPercent > 40)
        {
            GetComponent<Image>().sprite = sprites[2];
        }
        Debug.Log(GrowPercent);
    }
}
