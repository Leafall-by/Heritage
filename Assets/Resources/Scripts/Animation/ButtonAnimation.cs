using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
    private Animator _buttonAnim;
    
    private void Awake()
    {
    _buttonAnim = GetComponent<Animator>();
    }
    
    public void PlayAnimButton()
    {
        Debug.Log("12412412");
        _buttonAnim.SetTrigger("Click");
    }
}
