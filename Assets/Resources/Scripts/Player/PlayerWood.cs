using System;
using UnityEngine;

public class PlayerWood : MonoBehaviour
{
    public int Wood { get; set; }
    public const int MAX_WOOD = 50;
    
    public Action<int> WoodIsChanged;
    
    public void AddWood(int wood)
    {
        this.Wood += wood;
        
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
