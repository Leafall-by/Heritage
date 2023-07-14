using UnityEngine;

public class Bandits : Card
{
    [SerializeField] private Person bandits;
    public override void Use()
    {
        FindObjectOfType<DialogueController>().EnterDialogueMode(bandits.GetInputDialogue());
    }
}
