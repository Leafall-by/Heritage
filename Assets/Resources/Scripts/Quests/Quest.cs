using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public abstract class Quest : MonoBehaviour
{
    [HideInInspector] public UnityEvent<Quest> QuestIsFinished;

    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] public int id;
    [SerializeField] private int DayForComplete;

    public int currentDay;
    protected Player player;

    public virtual void Init(Player player)
    {
        this.player = player;
        timeText.text = $"Время до завершения: {DayForComplete - currentDay}";
    }

    public virtual void SkipDay()
    {
        currentDay++;

        if (currentDay >= DayForComplete)
        {
            FailQuest();
        }

        timeText.text = $"Время до завершения: {DayForComplete - currentDay}";
    }

    public abstract void TryCompleteQuest();

    public abstract void FailQuest();
}
