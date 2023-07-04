using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int gold;

    public Action<int> MoneyIsAdded;
    public Action<int> MoneyIsRemoved;
    public Action<GameObject> MoneyGameObjectIsRemoved;

    public void AddGold(int gold)
    {
        this.gold += gold;
        
        MoneyIsAdded?.Invoke(gold);
    }

    public void RemoveGold(int gold)
    {
        if (this.gold - gold < 0)
        {
            throw new NotEnoughGoldException("Не достаточно золота");
        }
        
        this.gold -= gold;
        
        MoneyIsRemoved?.Invoke(gold);
    }

    public void RemoveGold(GameObject money)
    {
        gold--;
        
        MoneyGameObjectIsRemoved?.Invoke(money);
    }
}
