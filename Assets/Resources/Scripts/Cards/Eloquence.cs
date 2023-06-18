using UnityEngine;

public class Eloquence : Card
{
    private ShopController controller;
    [SerializeField] private float discount;
    public override void Use()
    {
        controller = FindObjectOfType<ShopController>();
        Debug.Log(controller);
        controller.Discount = discount;
    }

    private void DisableCard()
    {
        controller.Discount = 0;
    }
}
