using UnityEngine;

public class Robbery : Card
{
    [SerializeField] private int moneyForRobbery;

    public override void Use()
    {
        Wallet wallet = FindObjectOfType<Wallet>();
        
        try
        {
            wallet.RemoveGold(moneyForRobbery);
        }
        catch (NotEnoughGoldException ex)
        {
            wallet.RemoveAllMoney();
        }
    }
}
