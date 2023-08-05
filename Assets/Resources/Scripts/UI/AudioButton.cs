using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioButton : MonoBehaviour
{
    [SerializeField] private AudioMixer mainAudio;
    [Space]
    [SerializeField] private Sprite off;
    [SerializeField] private Sprite on;
    
    private Image image;

    private bool audioIsEnable = true;
    private const string MAIN_VOLUME = "MainVolume";

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void OnClick()
    {
        int offSound = -80;
        int onSound = 0;
        
        if (audioIsEnable)
        {
            image.sprite = off;
            mainAudio.SetFloat(MAIN_VOLUME, offSound);
        }
        else
        {
            image.sprite = on;
            mainAudio.SetFloat(MAIN_VOLUME, onSound);
        }

        audioIsEnable = !audioIsEnable;
    }
}
