using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class AudioButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private AudioMixer mainAudio;
    private bool audioIsEnable = true;
    
    
    public void OnClick()
    {
        if (audioIsEnable)
        {
            text.text = "Выключен";
            mainAudio.SetFloat("MainVolume", -80);
        }
        else
        {
            text.text = "Включен";
            mainAudio.SetFloat("MainVolume", 0);
        }

        audioIsEnable = !audioIsEnable;
    }
}
