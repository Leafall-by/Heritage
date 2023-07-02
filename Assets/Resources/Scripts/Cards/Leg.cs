using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Leg : Card
{
    [SerializeField] private int timeCoefficient;
    public override void Use()
    {
        Debug.Log("Leg");

        CardUI cardUI = FindObjectOfType<CardHub>().cardUI;
        Card leg = cardUI.GetCards().FirstOrDefault(x => x is Leg);
        if (leg != null)
        {
            cardUI.DeleteCard(leg);
        }

        TimeController controller = FindObjectOfType<TimeController>();
        controller.Сoefficient = timeCoefficient;
    }
}
