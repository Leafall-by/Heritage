using Resources.Scripts.Animation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenCart : Card, IDependetForSpawn
{
    [SerializeField] private BrokenCartQuest quest;

    public bool IsCan()
    {
        return FindObjectOfType<Cart>() != null && FindObjectOfType<ChangeDayAnimation>().CartIsBroken != true;
    }

    public override void Use()
    {
        FindObjectOfType<ChangeDayAnimation>().CartIsBroken = true;
        FindObjectOfType<QuestController>().AddQuest(quest);
    }
}
