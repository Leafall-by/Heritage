using UnityEngine;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    public void Play()
    {
        _animator.SetBool("PlayGame", true);
    }
}
