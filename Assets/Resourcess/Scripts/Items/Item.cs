using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private string name;
    [SerializeField] private Image image;
    [SerializeField] private float price;

    public abstract void Use();
}
