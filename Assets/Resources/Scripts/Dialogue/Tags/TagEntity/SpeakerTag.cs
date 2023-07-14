using UnityEngine;

public class SpeakerTag : MonoBehaviour, ITag
{
    private DialogueWindow _dialogueWindow;
    private void Awake()
    {
        _dialogueWindow = GetComponent<DialogueWindow>();
    }

    public void Calling(string value)
    {
        _dialogueWindow.SetName(value);
    }
}
