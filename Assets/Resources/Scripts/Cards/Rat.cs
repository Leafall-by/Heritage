using UnityEngine;

public class Rat : Card
{
    [SerializeField] private int foodForMinus;
    public override void Use()
    {
        PlayerStats stats = FindObjectOfType<PlayerStats>();
        PlayerFood food = stats.PlayerFood;
        
        food.RemoveFood(foodForMinus);
    }
}
