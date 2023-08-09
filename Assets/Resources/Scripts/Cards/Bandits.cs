using UnityEngine;

public class Bandits : Card
{
    [SerializeField] private Person bandits;
    public override void Use()
    {
        if (bandits.IsAvaialable())
        {
            FindObjectOfType<DialogueController>().EnterDialogueMode(bandits.GetCurrentDialogue());
        } 
    }
}
