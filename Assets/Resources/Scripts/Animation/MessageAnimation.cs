using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Exit()
    {
        _animator.SetTrigger("Exit");
    }

    public void ChangeVisibleOnFalse()
    {
        this.gameObject.SetActive(false);
    }
}
