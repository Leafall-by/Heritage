using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anonim : Card
{
    public override void Use()
    {
        PersonHub hub = FindObjectOfType<PersonHub>();
        Person person = hub.GetAvailablePerson();

        if (person == null)
        {
            return;
        }
        
        DialogueController controller = FindObjectOfType<DialogueController>();
        controller.EnterDialogueMode(person.GetInputDialogue());
        person.IsWas = true;
    }
}
