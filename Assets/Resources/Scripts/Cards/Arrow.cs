using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : TimeCard
{
    private SeedMenuController controller;
    public override void Use()
    {
        controller = FindObjectOfType<SeedMenuController>();
        controller.IsCanSeed = false;
    }

    public override void CancelAction()
    {
        controller.IsCanSeed = true;
    }
}
