using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject canvas;
    [SerializeField] private Cell[] cells;
    [SerializeField] private ToolCell[] toolCells;

    public void ShowInventory()
    {
        SetItems(player.Inventory.GetItems(), player.Inventory.GetTools());
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

    public void CloseInventory()
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

}
