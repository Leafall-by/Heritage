using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Puddle : TimeCard
{
    [SerializeField] private int timeCoefficient;
    private TimeController controller;
    
    public override void Use()
    { 
        controller = FindObjectOfType<TimeController>();
        controller.Сoefficient += timeCoefficient;
    }

    public override void CancelAction()
    {
        controller.Сoefficient -= timeCoefficient;
    }
}
