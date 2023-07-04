using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Person", menuName = "Person", order = 51)]
public class Person : ScriptableObject
{
    public bool IsWas;

    [SerializeField] private TextAsset inputDialog;

    public TextAsset GetInputDialogue()
    {
        return inputDialog;
    }
}
