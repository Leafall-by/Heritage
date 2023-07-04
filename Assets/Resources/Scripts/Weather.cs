using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour
{
    public bool IsRain { get; private set; }
    [SerializeField] private ParticleSystem rain;

    public void StartRain()
    {
        IsRain = true;
        rain.Play();
    }

    public void StopRain()
    {
        IsRain = false;
        rain.Stop();
    }
}
