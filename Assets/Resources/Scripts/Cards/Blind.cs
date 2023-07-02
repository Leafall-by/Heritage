using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Blind : Card
{
    public int DayDuration;
    public override void Use()
    {
        Debug.Log("Blind");

        CardUI cardUI = FindObjectOfType<CardHub>().cardUI;
        Card blind = cardUI.GetCards().FirstOrDefault(x => x is Blind);
        if (blind != null)
        {
            cardUI.DeleteCard(blind);
        }
        
        FindObjectOfType<BlindController>().StartBlind(this);
    }
}
