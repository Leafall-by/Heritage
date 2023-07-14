using UnityEngine;

public class Puddle : TimeCard, IDependet
{
    [SerializeField] private int timeCoefficient;
    private TimeController controller;
    
    public override void Use()
    { 
        controller = FindObjectOfType<TimeController>();
        controller.Сoefficient += timeCoefficient;
    }

    public override void CancelAction()
    {
        controller.Сoefficient -= timeCoefficient;
    }

    public bool IsCan()
    {
        return FindObjectOfType<Weather>().IsRain;
    }
}
