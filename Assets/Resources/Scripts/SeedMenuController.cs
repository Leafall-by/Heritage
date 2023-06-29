using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedMenuController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GardenController controller;
    
    [SerializeField] private Cell[] cells;
    [SerializeField] private ToolCell toolCell;

    private void Start()
    {
        foreach (var cell in cells)
        {
            cell.OnUsed += UseSeed;
        }
    }

    public void ShowSeedMenu()
    {
        //canvas.SetActive(true);
        
        SetCellItems();
    }
    
    public void CloseSeedMenu()
    {
        DeleteCellItems();
        //canvas.SetActive(false);
    }

    private void RefreshCells()
    {
        
        DeleteCellItems();
        SetCellItems();
        
    }

    private void SetCellItems()
    {
        foreach (var item in player.Inventory.GetItems())
        {
            if (item.item is Seed)
            {
                GetAvaiableCell()?.SetItem(item);
            }
        }

        foreach (var tool in player.Inventory.GetTools())
        {
            if (tool is Hoe)
            {
                toolCell.SetItem(tool);
                break;
            }
        }
    }

    private void DeleteCellItems()
    {
        foreach (var cell in cells)
        {
            cell.DeleteItem();
        }
        toolCell.DeleteItem();
    }

    private void UseSeed(Item item)
    {
        foreach (var cell in cells)
        {
            if (controller.IsAvaiable() == false)
            {
                Debug.Log("Огород занят"); //TODO выводить в игре
                return;
            }
        }

        if (toolCell.item != null)
        {
            toolCell.item.endurance -= 25;
            item.Use();
        }
        
        
        player.Inventory.RemoveItem(item);
        RefreshCells();
    }
    
    private Cell GetAvaiableCell()
    {
        foreach (Cell cell in cells)
        {
            if (cell.IsAvailable())
            {
                return cell;
            }
        }

        return null;
    }
}
