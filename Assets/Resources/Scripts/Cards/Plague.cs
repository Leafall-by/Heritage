using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plague : Card
{
    public override void Use()
    {
        FindObjectOfType<PlagueController>().StartPlague();       
    }
}
