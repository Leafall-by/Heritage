using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class GlobalSaver : MonoBehaviour, ISaver
{
    [SerializeField] private Player player;
    [SerializeField] private ItemHub itemHub;
    [SerializeField] private Inventory inventory;
    [SerializeField] private CardHub cardHub;
    [SerializeField] private CardUI cardUI;
    [SerializeField] private CartSpawner cartSpawner;
    [SerializeField] private ShopController controller;
    [SerializeField] private DayChanger changer;
    [SerializeField] private QuestController questController;
    [SerializeField] private QuestHub questHub;
    
    private List<ISaver> savers = new List<ISaver>();

    private void Start()
    {
        savers.Add(new PlayerStatsSaver(player, changer));
        savers.Add(new ItemSaver(inventory, itemHub));
        savers.Add(new CardSaver(cardHub, cardUI));
        savers.Add(new CartSaver(cartSpawner, itemHub, controller));
        savers.Add(new QuestSaver(questController, questHub));
    }

    public void Save()
    {
        ISaver cartSaver = savers.First(x => x is CartSaver);
        ((CartSaver)cartSaver).AddCart(FindObjectOfType<Cart>());

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

    public bool HasSave()
    {
        return File.Exists(Application.persistentDataPath + "/Stats.dat");
    }
}
