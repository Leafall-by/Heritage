using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] public string name;
    [SerializeField] public Sprite image;
    [SerializeField] public int price;

    public abstract void Use();
}
