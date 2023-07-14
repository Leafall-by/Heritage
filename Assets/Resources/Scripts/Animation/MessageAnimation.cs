using UnityEngine;

public class MessageAnimation : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] private GameObject messageFront;
    [SerializeField] private GameObject messageBack;

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
