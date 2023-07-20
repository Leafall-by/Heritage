using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class CartSaver : ISaver
{
    private Cart cart;
    private CartSpawner cartSpawner;
    private ItemHub itemHub;
    private ShopController controller;

    public CartSaver(CartSpawner cartSpawner, ItemHub itemHub, ShopController controller)
    {
        this.cartSpawner = cartSpawner;
        this.itemHub = itemHub;
        this.controller = controller;
    }
    
    public void AddCart(Cart cart)
    {
        this.cart = cart;
    }
    
    public void Save()
    {
        CartData data = new CartData();

        if (cart == null)
        {
            data.isSpawn = false;
        }
        else
        {
            data.isSpawn = true;

            foreach (var item in cart.items)
            {
                if (item == null)
                {
                    data.idItems.Add(-1);
                    continue;
                }
                data.idItems.Add(item.id);
            }
        }

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Cart.dat");
        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath 
                        + "/Cart.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = 
                File.Open(Application.persistentDataPath 
                          + "/Cart.dat", FileMode.Open);
            CartData data = (CartData)bf.Deserialize(file);
            file.Close();

            if (data.isSpawn)
            {
                List<Item> items = new List<Item>();

                foreach (var id in data.idItems)
                {
                    if (id == -1)
                    {
                        items.Add(null);
                        continue;
                    }
                    items.Add(itemHub.FindItemByID(id));
                }
                
                cartSpawner.Spawn(items.ToArray()).SetShopController(controller);
            }
        }
        else
            Debug.LogError("There is no save data! (CartSaver)");
    }
}
