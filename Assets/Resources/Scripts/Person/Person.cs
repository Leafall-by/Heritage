using UnityEngine;

[CreateAssetMenu(fileName = "new Person", menuName = "Person", order = 51)]
public class Person : ScriptableObject
{
    [HideInInspector] public int dialogIndex; 

    [SerializeField] private TextAsset[] dayDialoges;

    public TextAsset GetCurrentDialogue()
    {
        TextAsset dialogue = dayDialoges[dialogIndex];
        dialogIndex++;

        return dialogue;
    }

    public bool IsAvaialable()
    {
        return dialogIndex < dayDialoges.Length;
    }
}
