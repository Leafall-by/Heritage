using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WarController : MonoBehaviour
{
    [SerializeField] private DialogueController dialogueController;
    [SerializeField] private Person knight;
    [SerializeField] private MoneyNewDayAdder moneyAdder;
    public UnityEvent WarIsStarted;

    private bool warIsStarted;

    public void StartWar()
    {
        moneyAdder.moneyForAdd = 0;

        //dialogueController.EnterDialogueMode(knight.GetCurrentDialogue());

        warIsStarted = true;
    }

    public void StopWar()
    {
        moneyAdder.moneyForAdd = 2;
    }

    public bool WarStarted()
    {
        return warIsStarted;
    }
}
