using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Settings;

public class Wolf : Card, IDependetForUse
{
    [SerializeField] private int KnifeEnduranceForRemove;

    public bool IsAlternative()
    {
        Item knife = FindObjectOfType<Player>().Inventory.FindItemByType(typeof(Knife));
        if (knife != null)
        {
            return true;
        }
        else return false;
    }

    public string GetAlternativeDescKey()
    {
        return "CardDesc_AlternativeWolf";
    }

    public override void Use()
    {
        

        PlayerStats stats = FindObjectOfType<PlayerStats>();
        PlayerFood food = stats.PlayerFood;

        if (food.Food <= 0)
        {
            //TODO Player's death
        }
        food.RemoveFood(food.Food);
    }

    public void UseAlternative()
    {
        Knife knife = (Knife)FindObjectOfType<Player>().Inventory.FindItemByType(typeof(Knife));
        knife.endurance -= KnifeEnduranceForRemove;
    }
}
