using UnityEngine;

public class War : Card, IDependetForSpawn
{
    [SerializeField] private int dayForSpawn;

    public bool IsCan()
    {
        return FindObjectOfType<DayChanger>().day == dayForSpawn;
    }

    public override void Use()
    {
        FindObjectOfType<WarController>().StartWar();
    }
}
