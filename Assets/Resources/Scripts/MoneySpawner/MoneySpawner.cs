using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    [SerializeField] private GameObject moneyPrefab;
    
    [SerializeField] private Wallet wallet;

    [SerializeField] private GameObject spawnPoint;

    private const float SPAWN_DELAY = 0.3f;

    private Stack<GameObject> golds;

    private void Start()
    {
        wallet.MoneyIsAdded += SpawnMoney;
        wallet.MoneyIsRemoved += RemoveMoney;

        golds = new Stack<GameObject>();
    }

    private void SpawnMoney(int countMoney)
    {
        StartCoroutine(SpawnMoneyCoroutine(countMoney));
    }

    private IEnumerator SpawnMoneyCoroutine(int countMoney)
    {
        for (int i = 0; i < countMoney; i++)
        {
            GameObject gold = Instantiate(moneyPrefab, spawnPoint.transform);
            golds.Push(gold);
            yield return new WaitForSeconds(SPAWN_DELAY);
        }
    }

    private void RemoveMoney(int countMoney)
    {
        for (int i = 0; i < countMoney; i++)
        {
            GameObject gold = golds.Pop();
            Destroy(gold);
        }
    }
}
