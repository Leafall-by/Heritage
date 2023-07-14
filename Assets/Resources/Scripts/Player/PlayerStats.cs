using System;
using UnityEngine;

[RequireComponent(typeof(PlayerWater), typeof(PlayerFood), typeof(PlayerWood))]
public class PlayerStats : MonoBehaviour
{
    public PlayerFood PlayerFood { get; private set; }
    public PlayerWater PlayerWater { get; private set; }
    public PlayerWood PlayerWood { get; private set; }

    public void Init()
    {
        PlayerFood = GetComponent<PlayerFood>();
        PlayerWater = GetComponent<PlayerWater>();
        PlayerWood = GetComponent<PlayerWood>();
    }
}
