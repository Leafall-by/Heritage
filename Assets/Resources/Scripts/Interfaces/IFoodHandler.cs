using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IFoodHandler
{
    event Action<int> FoodChanged;
}
