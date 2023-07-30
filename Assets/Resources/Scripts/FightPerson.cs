using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[CreateAssetMenu(fileName = "new FightPerson", menuName = "FightPerson", order = 53)]
public class FightPerson : ScriptableObject
{
    public Sprite sprite;
    public int Health;
    public Ability[] spells;
}
