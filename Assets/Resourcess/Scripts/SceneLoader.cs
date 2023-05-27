using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private int mainMenuIndex;

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(mainMenuIndex);
    }
}
