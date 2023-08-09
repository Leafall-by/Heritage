using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour
{
    [SerializeField] private GameObject spawnObject;
    [SerializeField] private Player player;
    [SerializeField] private DayChanger changer;

    private List<Quest> quests;

    private void Awake()
    {
        quests = new List<Quest>();
    }

    public void AddQuest(Quest quest)
    {
        Quest questGameobject = Instantiate(quest,spawnObject.transform);

        questGameobject.Init(player);
        quests.Add(questGameobject);

        changer.DayChanged.AddListener(questGameobject.SkipDay);
        questGameobject.QuestIsFinished.AddListener(DeleteQuest);
    }

    public void AddQuestWithDifferentDuration(Quest quest, int duration)
    {
        Quest questGameobject = Instantiate(quest, spawnObject.transform);

        questGameobject.currentDay = duration;
        questGameobject.Init(player);
        quests.Add(questGameobject);

        changer.DayChanged.AddListener(questGameobject.SkipDay);
        questGameobject.QuestIsFinished.AddListener(DeleteQuest);
    }

    private void DeleteQuest(Quest quest)
    {
        changer.DayChanged.RemoveListener(quest.SkipDay);
        quests.Remove(quest);
        quest.QuestIsFinished.RemoveAllListeners();
        Destroy(quest.gameObject);
    }

    public List<Quest> GetQuests()
    {
        return quests;
    }
}
