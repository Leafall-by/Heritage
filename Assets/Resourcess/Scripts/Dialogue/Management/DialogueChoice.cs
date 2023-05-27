using System;
using Ink.Runtime;
using TMPro;
using UnityEngine;

public class DialogueChoice : MonoBehaviour
{
    [SerializeField] private GameObject[] _choices;
    private TextMeshProUGUI[] _choicesText;

    public void Init()
    {
        _choicesText = new TextMeshProUGUI[_choices.Length];
        ushort index = 0;

        while (index < _choices.Length)
        {
            _choicesText[index] = _choices[index].GetComponentInChildren<TextMeshProUGUI>();
            index++;
        } 
    }

    public bool DisplayChoices(Story story)
    {
        Choice[] currentChoices = story.currentChoices.ToArray();

        if (currentChoices.Length > _choices.Length)
        {
            throw new ArgumentException("Ошибка! Выборов в сценарии больше, чем самих возможностей выбора в игре!");
        }

        HideChoices();

        ushort index = 0;

        foreach (Choice choice in currentChoices)
        {
            _choices[index].SetActive(true);
            _choicesText[index].text = choice.text;
            
            index++;
        }

        return currentChoices.Length > 0;
    }

    public void HideChoices()
    {
        foreach (GameObject choice in _choices)
        {
           choice.SetActive(false); 
        }
    }
}
