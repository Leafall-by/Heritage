using System.Linq;
using UnityEngine;

public class Eloquence : TimeCard
{
    private ShopController controller;
    [SerializeField] private float discount;
    public override void Use()
    {
        controller = FindObjectOfType<ShopController>();
        
        controller.Discount = discount;
    }

    public override void CancelAction()
    {
        controller.Discount = 0;
    }
}
