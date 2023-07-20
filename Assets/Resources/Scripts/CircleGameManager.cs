using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleGameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject gameCanvas;
    [SerializeField] private CircleMovement circleMovement;

    private int woodForAdd = 1;

    private void Start()
    {
        circleMovement.OnClick.AddListener(OnClicked);
    }

    public void StartGame()
    {
        Axe axe = (Axe)player.Inventory.FindItemByType(typeof(Axe));

        axe.endurance -= 25;
        if (axe.endurance <= 0)
        {
            player.Inventory.RemoveItem(axe);
        }
        
        gameCanvas.SetActive(true);
    }

    public void OnClicked(bool result)
    {
        if (result)
        {
            Win();
        }
        else StopGame();
    }

    public void Win()
    {
        player.PlayerStats.PlayerWood.AddWood(woodForAdd);
        StopGame();
    }

    private void StopGame()
    {
        gameCanvas.SetActive(false);
    }
}
