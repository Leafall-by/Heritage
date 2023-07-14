using UnityEngine;

public class DeleteMoneyArea : MonoBehaviour
{
    [SerializeField] private Wallet wallet;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Money"))
        {
            wallet.RemoveGold(other.gameObject);
        }
    }
}
