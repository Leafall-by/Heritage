using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaqueQuest : Quest
{
    public override void TryCompleteQuest()
    {
        if (player.Inventory.FindItemState(typeof(Medicine)).count >= 2)
        {
            QuestIsFinished.Invoke(this);
        }
    }

    public override void FailQuest()
    {
        FindObjectOfType<Death>().Die();
        QuestIsFinished.Invoke(this);
    }
}
