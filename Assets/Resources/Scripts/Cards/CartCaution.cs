using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartCaution : TimeCard, IDependetForSpawn
{
    [SerializeField] private int decreaseChance;

    public override void CancelAction()
    {
        CartSpawner cartSpawner = FindObjectOfType<CartSpawner>();
        cartSpawner.ChangeChanceToSpawn(decreaseChance);
    }

    public bool IsCan()
    {
        WarController controller = FindObjectOfType<WarController>();

        return controller.WarStarted();
    }

    public override void Use()
    {
        CartSpawner cartSpawner = FindObjectOfType<CartSpawner>();
        cartSpawner.ChangeChanceToSpawn(-decreaseChance);
    }
}
