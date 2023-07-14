using UnityEngine;

public class SeedMenuController : MonoBehaviour
{
    [SerializeField] private TimeController timeController;
    [SerializeField] private Player player;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GardenController controller;
    
    [SerializeField] private Cell[] cells;
    [SerializeField] private ToolCell toolCell;

    public bool IsCanSeed = true;

    private void Start()
    {
        foreach (var cell in cells)
        {
            cell.OnUsed += UseSeed;
        }
    }

    public void ShowSeedMenu()
    {
        SetCellItems();
    }
    
    public void CloseSeedMenu()
    {
        DeleteCellItems();
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
                Cell cell =  GetAvaiableCell();
                cell.SetItem(item);
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
        if (IsCanSeed == false)
        {
            return;
        }
        
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
        timeController.AddTime(60);
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
