using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Field : Card
{
    public override void Use()
    {
        Debug.Log("Field");

        Card field = FindObjectOfType<CardHub>().cardUI.GetCards().FirstOrDefault(x => x is Field);
        if (field != null)
        {
            Destroy(field.gameObject);
        }
        
        Weather weather = FindObjectOfType<Weather>();
        weather.StartRain();
    }
}
