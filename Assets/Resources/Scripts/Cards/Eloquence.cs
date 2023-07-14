using UnityEngine;

public class Eloquence : TimeCard
{
    [SerializeField] private float discount;
    public override void Use()
    {
        ShopController controller = FindObjectOfType<ShopController>();
        
        controller.Discount = discount;
    }

    public override void CancelAction()
    {
        ShopController controller = FindObjectOfType<ShopController>();
        
        controller.Discount = 0;
    }
}
