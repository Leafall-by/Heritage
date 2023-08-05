using System;
using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject canvas;
    [SerializeField] private Cell[] cells;
    [SerializeField] private ToolCell[] toolCells;

    [Header("Отображение страниц")]
    [SerializeField] private TextMeshProUGUI currentPageUI;
    [SerializeField] private TextMeshProUGUI maxPageUI;

    private int currentPage;

    public void ShowInventory()
    {
        SetItems(player.Inventory.GetItems()[0].ToArray(), player.Inventory.GetTools()[0].ToArray());
        maxPageUI.text = (player.Inventory.maxPages + 1).ToString();
    }

    private void SetItems(ItemState[] items, Tool[] tools)
    {
        foreach (var item in items)
        {
            GetAvaiableCell()?.SetItem(item);
        }

        foreach (var tool in tools)
        {
            GetAvaiableToolCell()?.SetItem(tool);
        }
    }

    public void FlipInventory(int direction)
    {
        if (player.Inventory.maxPages < currentPage + direction || currentPage + direction < 0)
        {
            return;
        }
    
        ClearInventory();

        currentPage += direction;
        currentPageUI.text = (currentPage + 1).ToString();

        SetItems(player.Inventory.GetItems()[currentPage].ToArray(), player.Inventory.GetTools()[currentPage].ToArray());
    }

    public void CloseInventory()
    {
        ClearInventory();

        currentPage = 0;
        //Потом через анимацию закрывается
    }

    public void ClearInventory()
    {
        for (int i = 0; i < cells.Length; i++)
        {
            cells[i].DeleteItem();
        }
        for (int i = 0; i < toolCells.Length; i++)
        {
            toolCells[i].DeleteItem();
        }
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

    private ToolCell GetAvaiableToolCell()
    {
        foreach (ToolCell cell in toolCells)
        {
            if (cell.IsAvailable())
            {
                return cell;
            }
        }

        return null;
    }

    private void OnDisable()
    {
        ClearInventory();
    }
}
