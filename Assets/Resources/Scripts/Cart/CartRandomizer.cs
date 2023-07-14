using UnityEngine;

public class CartRandomizer
{
    private const int PROCENT_CHANCE = 75;

    private Item[] items;

    public CartRandomizer(Item[] items)
    {
        this.items = items;
    }
    
    public bool IsSpawn()
    {
        float chance = Random.Range(0f, 100f);

        return chance < PROCENT_CHANCE;
    }

    public Item[] RandomizeItems()
    {
        Item[] itemsForSell = new Item[3];

        for (int i = 0; i < itemsForSell.Length; i++)
        {
            itemsForSell[i] = items[Random.Range(0, items.Length)];
            
        }
        
        return itemsForSell;
    }
}
