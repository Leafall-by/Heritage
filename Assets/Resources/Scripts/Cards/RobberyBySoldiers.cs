using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RobberyBySoldiers : Card, IDependetForSpawn
{
    [SerializeField] private int ChanceToRemoveTool;

    public bool IsCan()
    {
        return FindObjectOfType<WarController>().WarStarted();
    }

    public override void Use()
    {
        Inventory inventory = FindObjectOfType<Inventory>();

        List<List<Tool>> tools = inventory.GetTools();
        List<List<ItemState>> items = inventory.GetItems();

        if (tools[0].Count == 0 && items[0].Count == 0)
        {
            return;
        }

        float chance = Random.Range(0f, 100f);

        if (chance < ChanceToRemoveTool)
        {
            if (tools[0].Count != 0)
            {
                inventory.RemoveItem(GetRandomTool(inventory));
                return;
            }

            inventory.RemoveItem(GetRandomItemState(inventory).item);
            return;
        }

        if (items[0].Count != 0)
        {
            inventory.RemoveItem(GetRandomItemState(inventory).item);
            return;
        }

        inventory.RemoveItem(GetRandomTool(inventory));

    }

    private Item GetRandomTool(Inventory inventory)
    {
        List<List<Tool>> tools = inventory.GetTools();

        int toolListNumber = Random.Range(0, tools.Count + 1);

        int toolNumber = Random.Range(0, tools[toolListNumber].Count);

        return tools[toolListNumber][toolNumber];
    }

    private ItemState GetRandomItemState(Inventory inventory)
    {
        List<List<ItemState>> items = inventory.GetItems();

        int itemListNumber = Random.Range(0, items.Count + 1);

        int itemNumber = Random.Range(0, items[itemListNumber].Count);

        return items[itemListNumber][itemNumber];
    }
}
