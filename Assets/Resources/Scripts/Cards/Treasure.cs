using UnityEngine;

public class Treasure : Card
{
    [SerializeField] private int goldForAdd;
    public override void Use()
    {
        Wallet wallet = FindObjectOfType<Wallet>();
        wallet.AddGold(goldForAdd);
    }
}
