
using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Tags))]
public class DialogueTag : MonoBehaviour
{
    private Tags _tags;

    public void Init()
    {
        _tags = GetComponent<Tags>();
        _tags.Init();
    }

    public void HandleTags(List<string> tags)
    {
        if (tags.Count == 0)
        {
            return;
        }

        foreach (string tagValue in tags)
        {
            string[] keyTag = tagValue.Split(':');

            if (keyTag.Length != 2)
            {
                throw new ArgumentException("Ошибка! Неправильное оформление тега");
            }

            string key = keyTag[0].Trim();
            string value = keyTag[1].Trim();

            _tags.GetValue(key).Calling(value);

        }
    }
}
