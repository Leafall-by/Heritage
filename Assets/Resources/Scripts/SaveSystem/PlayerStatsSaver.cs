using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class PlayerStatsSaver : ISaver
{
    private PlayerStats stats;
    private Wallet wallet;
    private DayChanger day;
    
    public PlayerStatsSaver(Player player, DayChanger day)
    {
        this.stats = player.PlayerStats;
        wallet = player.Wallet;
        this.day = day;
    }
    
    public void Save()
    {
        StatsData data = new StatsData();
        data.food = stats.PlayerFood.Food;
        data.water = stats.PlayerWater.Water;
        data.wood = stats.PlayerWood.Wood;
        data.money = wallet.GetCountMoney();
        data.day = day.day; 

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Stats.dat");
        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath 
                        + "/Stats.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = 
                File.Open(Application.persistentDataPath 
                          + "/Stats.dat", FileMode.Open);
            StatsData data = (StatsData)bf.Deserialize(file);
            file.Close();
            
            stats.PlayerFood.AddFood(data.food);
            stats.PlayerWater.AddWater(data.water);
            stats.PlayerWood.AddWood(data.wood);
            wallet.AddGold(data.money);
            day.day = data.day;
        }
        else
            Debug.LogError("There is no save data!");
    }
}
