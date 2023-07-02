using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Blind : TimeCard
{
    private BlindController controller;
    
    public override void Use()
    {
        controller = FindObjectOfType<BlindController>();
        controller.StartBlind(this);
    }

    public override void CancelAction()
    {
        controller.StopBlind();
    }
}
