using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    public void Play()
    {
        _animator.SetBool("PlayGame", true);
    }
}
