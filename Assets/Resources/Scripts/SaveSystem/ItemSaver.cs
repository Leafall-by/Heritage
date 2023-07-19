using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class ItemSaver : ISaver
{
    private Inventory inventory;
    private ItemHub itemHub;
    
    public ItemSaver(Inventory inventory, ItemHub itemHub)
    {
        this.inventory = inventory;
        this.itemHub = itemHub;
    }
    
    public void Save()
    {
        ItemData data = new ItemData();
        
        foreach (var itemList in inventory.GetItems())
        {
            foreach (var itemState in itemList)
            {
                for (int i = 0; i < itemState.count; i++)
                {
                    data.idItems.Add(itemState.item.id);
                }
            }
        }

        data.maxPage = inventory.maxPages;
        
        foreach (var toolList in inventory.GetTools())
        {
            foreach (var tool in toolList)
            {
                data.idItems.Add(tool.id);
            }
        }
        
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Items.dat");
        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath 
                        + "/Items.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = 
                File.Open(Application.persistentDataPath 
                          + "/Items.dat", FileMode.Open);
            ItemData data = (ItemData)bf.Deserialize(file);
            file.Close();

            for (int i = 0; i < data.maxPage - 1; i++)
            {
                inventory.ExpandInventory();
            }
            
            foreach (var itemId in data.idItems)
            {
                inventory.AddItem(itemHub.FindItemByID(itemId));
            }
        }
        else
            Debug.LogError("There is no save data!");
    }
}
