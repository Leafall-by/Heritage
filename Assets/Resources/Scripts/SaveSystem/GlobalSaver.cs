using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSaver : MonoBehaviour, ISaver
{
    [SerializeField] private PlayerStats stats;
    [SerializeField] private ItemHub itemHub;
    [SerializeField] private Inventory inventory;
    [SerializeField] private CardHub cardHub;
    [SerializeField] private CardUI cardUI;
    
    
    private List<ISaver> savers = new List<ISaver>();

    private void Start()
    {
        savers.Add(new PlayerStatsSaver(stats));
        savers.Add(new ItemSaver(inventory, itemHub));
        savers.Add(new CardSaver(cardHub, cardUI));
    }

    public void Save()
    {
        foreach (var saver in savers)
        {
            saver.Save();
        }
    }

    public void Load()
    {
        foreach (var saver in savers)
        {
            saver.Load();
        }
    }
}
