using UnityEngine;

public class GardenAnimation : MonoBehaviour
{   private Animator _animator;

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
    }

    public void Exit()
    {
        _animator.SetTrigger("Exit");
    }

    public void SetActive()
    {
        gameObject.SetActive(false);
    }
}
