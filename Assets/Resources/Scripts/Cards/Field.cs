using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Field : Card
{
    public override void Use()
    {
        Debug.Log("Field");

        CardUI cardUI = FindObjectOfType<CardHub>().cardUI;
        Card field = cardUI.GetCards().FirstOrDefault(x => x is Field);
        if (field != null)
        {
            cardUI.DeleteCard(field);
        }
        
        
        Weather weather = FindObjectOfType<Weather>();
        weather.StartRain();
    }
}
