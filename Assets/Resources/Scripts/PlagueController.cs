using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueController : MonoBehaviour
{
    [SerializeField] private DayChanger dayChanger;
    [SerializeField] private DialogueController dialogueController;
    [SerializeField] private Person witchDoctor;

    [Header("quests")]
    [SerializeField] private QuestController questController;
    [SerializeField] private PlaqueQuest quest;

    private const int chanceToGetPlague = 100;
    public bool PlagueIsStart { get; private set; }
    private bool IsInfected;

    public void StartPlague()
    {
        PlagueIsStart = true;

        if (witchDoctor.IsAvaialable())
        {
            dialogueController.EnterDialogueMode(witchDoctor.GetCurrentDialogue());
        }

        dayChanger.DayChanged.AddListener(TryInfected);
    }

    public void StopPlague()
    {
        dayChanger.DayChanged.RemoveListener(TryInfected);
    }

    private void TryInfected()
    {
        if (IsInfected)
            return;

        int chance = Random.Range(0, 101);

        if (chance < chanceToGetPlague)
        {
            questController.AddQuest(quest);
            IsInfected = true;
        }
    }
}
