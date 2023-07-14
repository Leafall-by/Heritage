using UnityEngine;
using UnityEngine.UI;

public class Dog : MonoBehaviour
{
    public bool IsExist { get; private set; }

    public void Spawn()
    {
        GetComponent<Image>().enabled = true;
        IsExist = true;
    }
}
