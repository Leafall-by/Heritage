using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private GameObject deathCanvas;
    [SerializeField] private DayChanger dayChanger;
    
    [SerializeField] private PlayerStats playerStats;

    private void Start()
    {
        dayChanger.DayChanged.AddListener(TryDie);
    }

    private void TryDie()
    {
        //if (playerStats.PlayerWater.Water < 0 || playerStats.PlayerFood.Food < 0 || playerStats.PlayerWood.Wood < 0)
        //{
        //    Die();
        //}
    }

    public void Die()
    { 
        //deathCanvas.SetActive(true);
    }
}
