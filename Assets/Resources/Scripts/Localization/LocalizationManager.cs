using System;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocalizationManager : MonoBehaviour
{
    public int CurrentLanguage;

    public void SetLanguage(int languageNumber)
    {
        StartCoroutine(SetLanguageCoroutine(languageNumber));
    }
    
    private IEnumerator SetLanguageCoroutine(int languageNumber)
    {
        yield return LocalizationSettings.InitializationOperation;

        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[languageNumber];
    }
}
