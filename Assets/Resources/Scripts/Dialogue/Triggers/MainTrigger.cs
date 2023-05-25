using UnityEngine;

public abstract class MainTrigger : MonoBehaviour
{
    [SerializeField] protected DialogueController _dialogueController;
    [SerializeField] private DialogueWindow _dialogueWindow;

    public void CallHistory()
    {
        if (_dialogueWindow.IsPlaying == true)
        {
            return;
        }
        
        Call();
    }

    
    protected abstract void Call();
}
