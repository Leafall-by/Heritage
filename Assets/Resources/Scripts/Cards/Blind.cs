using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Blind : TimeCard, IDependet
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

    public bool IsCan()
    {
        FindBlindController();
        return !controller.IsBlind;
    }

    private void FindBlindController()
    {
        controller = FindObjectOfType<BlindController>();   
    }
}
