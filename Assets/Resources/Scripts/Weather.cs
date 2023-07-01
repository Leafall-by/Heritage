using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour
{
    public bool IsRain { get; private set; }

    public void StartRain()
    {
        IsRain = true;
    }
}
