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

        Card legCard = FindObjectOfType<CardHub>().cardUI.GetCards().FirstOrDefault(x => x is Leg);
        if (legCard != null)
        {
            Destroy(legCard.gameObject);
        }

        TimeController controller = FindObjectOfType<TimeController>();
        controller.Сoefficient = timeCoefficient;
    }
}
