using System.Collections;
using System;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField] private DayChanger dayChanger;
    private DateTime time;
    
    public int Сoefficient { get; set; }

    private void Start()
    {
        time = new DateTime(1000, 01, 01, 6, 0, 0);
    }

    public void AddTime(int minutes)
    {
        int day = time.Day;
        minutes += (minutes * Сoefficient / 100);
        time = time.AddMinutes(minutes);
        Debug.Log("Время: "+ time);
        TrySkipDay(day);
    }

    private void TrySkipDay(int oldDay)
    {
        if (time.Hour >= 22 || oldDay < time.Day)
        {
            dayChanger.ChangeDay();

            time = new DateTime(1000, 01, 01, 6, 0, 0);
        }
    }
}
