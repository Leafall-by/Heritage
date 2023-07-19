using UnityEngine;
using UnityEngine.UI;

public class Dog : MonoBehaviour
{
    public bool IsExist { get; private set; }

    [SerializeField] private GameObject dog;
    [SerializeField] private GameObject shadow;

    public void Spawn()
    {
        IsExist = true;
        
        dog.SetActive(true);
        shadow.SetActive(true);
    }
}
