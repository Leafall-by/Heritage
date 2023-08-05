using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenRobbery : Card, IDependetForSpawn
{
    public bool IsCan()
    {
        return FindObjectOfType<WarController>().WarStarted();
    }

    public override void Use()
    {
        FindObjectOfType<GardenController>().DeleteAll();
    }
}
