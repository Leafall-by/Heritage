using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedMenuController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject canvas;

    [SerializeField] private Cell[] cells;
    
    public void ShowSeedMenu()
    {
        canvas.SetActive(true);
        
        foreach (var item in player.Inventory.GetItems())
        {
            if (item.item is Seed)
            {
                GetAvaiableCell()?.SetItem(item);
            }
        }
    }
    
    public void CloseSeedMenu()
    {
        for (int i = 0; i < cells.Length; i++)
        {
            cells[i].DeleteItem();
        }
        
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
}
