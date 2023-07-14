using TMPro;
using UnityEngine;

public class WalletUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldText;
    
    [SerializeField] private GameObject spawnPoint;

    private int goldCount;

    public void SpawnMoney(GameObject gold)
    {
        gold.transform.position = spawnPoint.transform.position;
        gold.transform.SetParent(spawnPoint.transform);
        
        goldCount++;
        goldText.text = goldCount.ToString();
    }

    public void RemoveGold(GameObject gold)
    {
        Destroy(gold);
        goldCount--;
        goldText.text = goldCount.ToString();
    }
}
