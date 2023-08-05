using TMPro;
using UnityEngine;

public class NotificaitionController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private TextMeshProUGUI _textUI;
    
    private static readonly string ToPlayer = "SendToPlayer";
    private static readonly string CloseWindow = "Close";

    public void SetMessage(string text)
    {
        _textUI.text = text;
    }

    public void SendToPlayer()
    {
        _animator.SetTrigger(ToPlayer);
    }
    
    public void CloseNotificationWindow()
    {
        _animator.SetTrigger(CloseWindow);
    }
}
