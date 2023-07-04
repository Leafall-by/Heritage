using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mail : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private GameObject messageCanvas;
    
    public void OpenMessage(string text)
    {
        messageCanvas.SetActive(true);
        
        messageText.text = text;
    }
}
