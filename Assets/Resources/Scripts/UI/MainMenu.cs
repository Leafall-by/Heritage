using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private TextMeshProUGUI playText;
    [SerializeField] private GlobalSaver saver;


    [SerializeField] private TextMeshProUGUI loadText;
    [SerializeField] private TextMeshProUGUI startText;

    private void Start()
    {
        if (saver.HasSave())
        {
            loadText.gameObject.SetActive(true);
            startText.gameObject.SetActive(false);

            return;
        }

        loadText.gameObject.SetActive(false);
        startText.gameObject.SetActive(true);
    }

    public void Load()
    {
        if (saver.HasSave())
        {
            saver.Load();
        }
        _animator.SetBool("PlayGame", true);
    }


    public void Exit()
    {
        Application.Quit();
    }
}
