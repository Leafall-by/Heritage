using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueController : MonoBehaviour
{
    [SerializeField] private DayChanger dayChanger;
    [SerializeField] private DialogueController dialogueController;
    [SerializeField] private Person witchDoctor;

    public bool PlagueIsStart { get; private set; }

    public void StartPlague()
    {
        PlagueIsStart = true;

        dialogueController.EnterDialogueMode(witchDoctor.GetCurrentDialogue());
    }

    public void StopPlague()
    {

    }
}
