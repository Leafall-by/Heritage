using UnityEngine;

public class CartSpawner : MonoBehaviour
{
    [SerializeField] private Item[] items;
    [SerializeField] private Cart prefabCart;
    [SerializeField] private GameObject _spawnPoint;
    private CartRandomizer randomizer;

    public Cart TrySpawn()
    {
        randomizer = new CartRandomizer(items);
        
        if (randomizer.IsSpawn())
        {
            Cart cart = Instantiate(prefabCart, _spawnPoint.transform);
            cart.SetItems(randomizer.RandomizeItems());
            return cart;
        }
        else return null; //TODO Ошибку, если телега не приехала
    }
}
