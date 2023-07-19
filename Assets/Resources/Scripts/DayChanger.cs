using Resources.Scripts.Animation;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CartSpawner))]
public class DayChanger : MonoBehaviour
{
    [HideInInspector] public int day { get; set; }

    private CartSpawner cartSpawner;

    private Cart cart;

    [SerializeField] private ShopController shopController;
    [SerializeField] private GardenController gardenController;
    [SerializeField] private CardGiverUI cardGiverUI;
    
    //TODO: Вынести в отдельный класс
    [SerializeField] private ChangeDayAnimation dayAnimation;
    [SerializeField] private DayData dayGUI;
    [SerializeField] private GameObject _spawnPoint;

    public UnityEvent DayChanged;
    private void Start()
    {
        cartSpawner = GetComponent<CartSpawner>();
    }

    public void DeleteCart()
    {
        if (cart == null)
        {
            return;
        }
        
        Destroy(cart.gameObject);
    }

    public void ChangeDay()
    {
        day++;
        gardenController.Grow();
        dayAnimation.ChangeDay();
        dayGUI.day = day;
        DayChanged?.Invoke();
    }
    
    //Спавн карт в анимации.
    public void ShowCards()
    {
        cardGiverUI.ShowCanvas();
        cardGiverUI.RandomizeCards();
    }

    //Лошадь спавнится в анимации
    public void SpawnCart()
    {
        cart = cartSpawner.TrySpawn();
        if (cart == null)
        {
            return;
        }
        cart.SetShopController(shopController);
    }
}
