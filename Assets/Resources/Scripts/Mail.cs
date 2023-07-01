using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mail : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageText;
    
    public void OpenMessage(string text)
    {
        messageText.text = text;
    }
}
