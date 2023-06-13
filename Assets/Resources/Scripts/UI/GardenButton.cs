using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GardenButton : MonoBehaviour
{
    [SerializeField] private SeedMenuController seedMenuController;
    private bool isOpen = false;

    public void Click()
    {
        if (isOpen)
        {
            seedMenuController.CloseSeedMenu();
            isOpen = false;
        }
        else
        {
            seedMenuController.ShowSeedMenu();
            isOpen = true;
        }
    }
}
