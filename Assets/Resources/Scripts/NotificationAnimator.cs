using UnityEngine;

public class NotificationAnimator : MonoBehaviour
{
    [SerializeField] private NotificaitionController _controller;

    public void Close()
    {
        _controller.CloseNotificationWindow();
    }
}
