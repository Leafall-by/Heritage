using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plague : Card, IDependetForSpawn
{
    [SerializeField] private int dayForSpawn;

    public bool IsCan()
    {
        return FindObjectOfType<DayChanger>().day == dayForSpawn;
    }

    public override void Use()
    {
        FindObjectOfType<PlagueController>().StartPlague();
    }
}
