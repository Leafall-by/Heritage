using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class CartSpawner : MonoBehaviour
{
    [SerializeField] private Item[] items;
    [SerializeField] private Cart prefabCart;
    [SerializeField] private GameObject _spawnPoint;
    private CartRandomizer randomizer;

    [HideInInspector] private int ChanceToSpawn = 75;

    public void ChangeChanceToSpawn(int chanceToChange)
    {
        ChanceToSpawn += chanceToChange;
    }

    public Cart TrySpawn()
    {
        randomizer = new CartRandomizer(items);
        
        if (randomizer.IsSpawn(ChanceToSpawn))
        {
            Cart cart = Instantiate(prefabCart, _spawnPoint.transform);
            Item[] items = randomizer.RandomizeItems();

            foreach (var itemPrefab in items)
            {
                cart.AddItem(itemPrefab);
            }
            return cart;
        }
        else return null; //TODO Ошибку, если телега не приехала
    }

    public Cart Spawn(Item[] items)
    {
        Cart cart = Instantiate(prefabCart, _spawnPoint.transform);

        foreach (var item in items)
        {
            cart.AddItem(item);
        }

        return cart;
    } 
}
