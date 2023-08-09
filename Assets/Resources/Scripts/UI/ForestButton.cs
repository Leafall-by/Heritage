using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestButton : MonoBehaviour
{
    [SerializeField] private GameObject forestCanvas;
    [SerializeField] private DialogueController dialogueController;
    [SerializeField] private Person robinGood;

    private int isFirstOpen = 1;

    private void Start()
    {
        if (PlayerPrefs.HasKey("ForestIsFirstOpen"))
        {
            isFirstOpen = PlayerPrefs.GetInt("ForestIsFirstOpen");
        }
    }

    public void OpenForest()
    {
        if (isFirstOpen == 1)
        {
            dialogueController.EnterDialogueMode(robinGood.GetCurrentDialogue());

            isFirstOpen = 0;
            PlayerPrefs.SetInt("ForestIsFirstOpen", 0);
        }

        forestCanvas.SetActive(true);
    }
}
