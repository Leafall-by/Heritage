using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CardData
{
    public Dictionary<int, int> timeCards;

    public CardData()
    {
        timeCards = new Dictionary<int, int>();
    }
}
