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
        _buttonAnim.SetTrigger("Click");
    }
}
