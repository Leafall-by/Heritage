using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyNewDayAdder : MonoBehaviour
{
    [SerializeField] private Wallet wallet;
    public int moneyForAdd { get; set; }

    public void AddMoney()
    {
        wallet.AddGold(moneyForAdd);
    }
}
