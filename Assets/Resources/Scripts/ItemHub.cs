using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemHub : MonoBehaviour
{
    [SerializeField] private List<Item> items;

    public Item FindItemByID(int id)
    {
        return items.First(x => x.id == id);
    }
}
