using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Rain : TimeCard
{
    private Weather weather;
    public override void Use()
    {
        weather = FindObjectOfType<Weather>();
        weather.StartRain();
    }

    public override void CancelAction()
    {
        weather.StopRain();
    }
}
