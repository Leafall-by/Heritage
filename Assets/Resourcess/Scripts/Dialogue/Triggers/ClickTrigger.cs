using System;
using UnityEngine;

public class ClickTrigger : MainTrigger
{
    [SerializeField] private TextAsset _history;
    
    protected override void Call()
    {
        _dialogueController.EnterDialogueMode(_history);
    }
}
