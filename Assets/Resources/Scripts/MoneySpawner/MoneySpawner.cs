using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    [SerializeField] private GameObject moneyPrefab;
    
    [SerializeField] private Wallet wallet;

    [SerializeField] private WalletUI walletUI;

    private const float SPAWN_DELAY = 0.3f;

    private List<GameObject> golds;

    private void Start()
    {
        wallet.MoneyIsAdded += SpawnMoney;
        wallet.MoneyIsRemoved += RemoveMoney;
        wallet.MoneyGameObjectIsRemoved += RemoveGameObjectMoney;

        golds = new List<GameObject>();
    }

    public void SpawnMoney(int countMoney)
    {
        StartCoroutine(SpawnMoneyCoroutine(countMoney));
    }

    private IEnumerator SpawnMoneyCoroutine(int countMoney)
    {
        for (int i = 0; i < countMoney; i++)
        {
            GameObject gold = Instantiate(moneyPrefab);
            golds.Add(gold);
            walletUI.SpawnMoney(gold);
            yield return new WaitForSeconds(SPAWN_DELAY);
        }
    }

    private void RemoveMoney(int countMoney)
    {
        for (int i = 0; i < countMoney; i++)
        {
            GameObject gold = golds[golds.Count-1];
            golds.Remove(golds[golds.Count-1]);
            walletUI.RemoveGold(gold);
        }
    }

    private void RemoveGameObjectMoney(GameObject gold)
    {
        golds.Remove(gold);
        walletUI.RemoveGold(gold);
    }

}
