using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueController : MonoBehaviour
{
    [SerializeField] private DayChanger dayChanger;
    [SerializeField] private DialogueController dialogueController;
    [SerializeField] private Person witchDoctor;

    private const int chanceToGetPlague = 5;
    public bool PlagueIsStart { get; private set; }

    private void Start()
    {
    }

    public void StartPlague()
    {
        PlagueIsStart = true;

        dialogueController.EnterDialogueMode(witchDoctor.GetCurrentDialogue());
    }

    public void StopPlague()
    {

    }

    private void TryGetPlague()
    {

    }
}
