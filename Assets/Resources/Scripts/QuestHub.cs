using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestHub : MonoBehaviour
{
    [SerializeField] private Quest[] quests;

    public Quest GetQuestById(int id)
    {
        foreach (var quest in quests)
        {
            if (quest.id == id)
            {
                return quest;
            }
        }

        return null; //TODO
    }
}
