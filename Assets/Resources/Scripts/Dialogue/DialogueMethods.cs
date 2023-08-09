using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueMethods : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private ItemHub itemHub;

    public void GetMoney(int value)
    {
        player.Wallet.AddGold(value);
    }

    public void RemoveMoney(int value)
    {
        if (player.Wallet.GetCountMoney() < value)
        {
            player.Wallet.RemoveGold(player.Wallet.GetCountMoney());
        }
        else player.Wallet.RemoveGold(value);
    }

    public void GetItem(int idItem)
    {
        Item item = itemHub.FindItemByID(idItem);

        if (player.Inventory.CheckCanAdd(item))
        {
            player.Inventory.AddItem(item);
        }
        else Debug.LogError("Предмет не добавился"); //TODO
    }

}
