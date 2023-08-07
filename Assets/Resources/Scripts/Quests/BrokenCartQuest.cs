using Resources.Scripts.Animation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenCartQuest : Quest
{
    [SerializeField] private int woodForComplete;

    public override void FailQuest()
    {
        FindObjectOfType<ChangeDayAnimation>().CartIsBroken = false;
        QuestIsFinished.Invoke(this);
    }

    public override void TryCompleteQuest()
    {
        if (player.PlayerStats.PlayerWood.Wood >= woodForComplete)
        {
            player.PlayerStats.PlayerWood.RemoveWood(woodForComplete);
            FindObjectOfType<ChangeDayAnimation>().CartIsBroken = false;

            QuestIsFinished.Invoke(this);
        }
    }
}
