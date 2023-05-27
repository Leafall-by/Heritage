using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject canvas;
    [SerializeField] private Cell[] cells;
    [SerializeField] private Cell[] toolCells;

    public void ShowInventory()
    {
        canvas.SetActive(true);
        SetItems(player.Inventory.GetItems().ToArray());
    }

    public void SetItems(ItemState[] items)
    {
        foreach (var item in items)
        {
            if (item.item is Tool tool)
            {
                GetAvaiableToolCell()?.SetItem(item);
            }
            else GetAvaiableCell()?.SetItem(item);
        }
    }

    public void CloseShop()
    {
        for (int i = 0; i < cells.Length; i++)
        {
            cells[i].DeleteItem();
        }
        // for (int i = 0; i < toolCells.Length; i++)
        // {
        //     toolCells[i].DeleteItem();
        // }

        canvas.SetActive(false);
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

    private Cell GetAvaiableToolCell()
    {
        foreach (Cell cell in toolCells)
        {
            if (cell.IsAvailable())
            {
                return cell;
            }
        }

        return null;
    }

}
