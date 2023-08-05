using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : Item, IDependetForSpawn
{
    public bool IsCan()
    {
        return FindObjectOfType<PlagueController>().PlagueIsStart;
    }

    public override void Use()
    {
    }
}
