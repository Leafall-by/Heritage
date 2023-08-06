using System.Collections;
using TMPro;
using UnityEngine;

public class NotificaitionController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private TextMeshProUGUI _textUI;
    
    private static readonly string ToPlayer = "IsSending";
    private readonly float _waitTime = 4;

    private Coroutine _coroutine;
    
    public void ShowNotification(string text)
    {
        StartCoroutine(SendToPlayer(text));
        
    }

    private IEnumerator HideNotification()
    {
        yield return new WaitForSeconds(_waitTime);
        CloseNotificationWindow();
        _coroutine = null;
    }
    
    private void SetMessage(string text)
    {
        _textUI.text = text;
    }  
    
    private IEnumerator SendToPlayer(string text)
    {
        CloseNotificationWindow();
        yield return new WaitForSeconds(0.1f);
        SetMessage(text);
        _animator.SetBool(ToPlayer, true);
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
        
        _coroutine = StartCoroutine(HideNotification());
    }
    
    public void CloseNotificationWindow()
    {
        _animator.SetBool(ToPlayer, false);
    }
}
