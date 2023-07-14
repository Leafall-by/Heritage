using UnityEngine;

public class Alcohol : Card
{
    [SerializeField] private int MinutesForSkip;
    
    public override void Use()
    {
        FindObjectOfType<TimeController>().AddTime(MinutesForSkip);
    }
}
