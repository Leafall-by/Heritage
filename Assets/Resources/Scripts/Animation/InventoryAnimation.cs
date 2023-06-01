using UnityEngine;

public class InventoryAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void ChangeState(bool state)
    {
        _animator.SetBool("IsEntered", state);
    }
}
    
