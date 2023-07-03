using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    public bool IsWas;

    [SerializeField] private TextAsset inputDialog;

    public TextAsset GetInputDialogue()
    {
        return inputDialog;
    }
}
