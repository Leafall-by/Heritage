public class Anonim : Card, IDependet
{
    public override void Use()
    {
        Person person = GetAvailablePerson();

        if (person == null)
        {
            return; //todo ошибку
        }
        
        DialogueController controller = FindObjectOfType<DialogueController>();
        controller.EnterDialogueMode(person.GetInputDialogue());
        person.IsWas = true;
    }

    public bool IsCan()
    {
        Person person = GetAvailablePerson();

        if (person == null)
        {
            return false;
        }
        else return true;
    }

    private Person GetAvailablePerson()
    {
        PersonHub hub = FindObjectOfType<PersonHub>();
        Person person = hub.GetAvailablePerson();

        return person;
    }
}
