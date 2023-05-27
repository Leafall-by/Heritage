using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpeakerTag),typeof(ImageTag))]
public class Tags : MonoBehaviour
{
    private readonly Dictionary<string, ITag> _tags = new();

    public void Init()
    {
        _tags.Add("speaker", GetComponent<SpeakerTag>());
        _tags.Add("image", GetComponent<ImageTag>());
    }

    public ITag GetValue(string key)
    {
        return _tags.GetValueOrDefault(key);
    }
}
