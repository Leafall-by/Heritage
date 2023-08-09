using System;
using UnityEngine;

public class VisibilityMenu : MonoBehaviour
{
    private Animator _animator;
    private string _name = "Visible";
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetPause()
    {
        _animator.SetBool(_name, false);
    }
    public void SetResume()
    {
        _animator.SetBool(_name, true);
    }
}
