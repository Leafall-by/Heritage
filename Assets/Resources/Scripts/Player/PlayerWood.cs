using System;
using UnityEngine;

public class PlayerWood : MonoBehaviour
{
    public int Wood { get; set; }
    public const int MAX_WOOD = 50;
    
    [HideInInspector] public Action<int> WoodIsChanged;

    private int multiplier = 1;

    public void AddWood(int wood)
    {
        this.Wood += wood * multiplier;
        
        if (wood > MAX_WOOD)
        {
            wood = MAX_WOOD;
        }
        
        WoodIsChanged?.Invoke(this.Wood);
    }

    public void RemoveWood(int wood)
    {
        this.Wood -= wood;
        WoodIsChanged?.Invoke(this.Wood);
    }
}
