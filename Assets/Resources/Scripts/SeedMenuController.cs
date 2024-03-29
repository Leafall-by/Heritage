using UnityEngine;

public class SeedMenuController : MonoBehaviour
{
    [SerializeField] private TimeController timeController;
    [SerializeField] private Player player;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GardenController gardenController;
    [SerializeField] private NotificaitionController notificationController;
    
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
        foreach (var itemStateList in player.Inventory.GetItems())
        {
            foreach (var item in itemStateList)
            {
                if (item.item is Seed)
                {
                    Cell cell =  GetAvaiableCell();
                    cell.SetItem(item);
                }    
            }
            
        }
        
        foreach (var toolList in player.Inventory.GetTools())
        {
            foreach (var tool in toolList)
            {
                if (tool is Hoe)
                {
                    toolCell.SetItem(tool);
                    break;
                }
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
            notificationController.ShowNotification("Карта Arrow не позволяет сажать");
            return;
        }
        
        foreach (var cell in cells)
        {
            if (gardenController.IsAvaiable() == false)
            {
                notificationController.ShowNotification("Огород занят");
                return;
            }
        }

        if (toolCell.item != null)
        {
            toolCell.item.endurance -= 25;
            if (toolCell.item.endurance <= 0)
            {
                player.Inventory.RemoveItem(toolCell.item);
            }
        }
        else
        {
            notificationController.ShowNotification("Нет мотыги");
            return;
        }

        player.Inventory.RemoveItem(item);
        item.Use();
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
