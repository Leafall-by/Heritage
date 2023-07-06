using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Weather : MonoBehaviour
{
    public bool IsRain { get; private set; }
    [SerializeField] private ParticleSystem rain;
    [SerializeField] private Image sky;
    [SerializeField] private Image[] _elements;
    
    public readonly UnityEvent StartRainEvent = new UnityEvent();

    public void StartRain()
    {
        IsRain = true;
        sky.color = new Color(0.3f, 0.3f, 0.3f);
        SetColorOnElements(new Color(0.6f, 0.6f,0.6f));
        StartRainEvent.Invoke();
        rain.Play();
    }

    public void StopRain()
    {
        IsRain = false;
        sky.color = Color.white;
        SetColorOnElements(Color.white);
        rain.Stop();
    }

    private void SetColorOnElements(Color color)
    {
        foreach (var element in _elements)
        {
            element.color = color;
        }
    }
}
