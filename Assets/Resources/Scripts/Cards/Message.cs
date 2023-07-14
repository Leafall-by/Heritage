using UnityEngine;

public class Message : Card
{
    [SerializeField] private string text;
    
    public override void Use()
    {
        Mail mail = FindObjectOfType<Mail>();
        mail.OpenMessage(text);
    }
} 
