
using System;
using System.Collections.Generic;
using UnityEngine;

public class ImageTag : MonoBehaviour, ITag
{
    private readonly Dictionary<string, Sprite> _dictionary = new();
    [SerializeField] private Sprite _witchDoctorSprite;
    [SerializeField] private DialogueWindow _dialogueWindow;

    private void Awake()
    {
        _dictionary.Add("witch_doctor", _witchDoctorSprite);
    }

    public void Calling(string value)
    {
        Sprite sprite = _dictionary.GetValueOrDefault(value);
        _dialogueWindow.SetSpriteImage(sprite);
    }
}
