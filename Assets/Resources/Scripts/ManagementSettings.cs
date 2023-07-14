using UnityEngine;

public class ManagementSettings : MonoBehaviour
{
    [SerializeField] private GameObject cheatPanel;
    private bool _isActive = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            _isActive = !_isActive;
            cheatPanel.SetActive(_isActive);
        }
    }
}
