using UnityEngine;

public class ShopAnimation : MonoBehaviour
{
    private Animator _animator;
    [SerializeField]private GameObject _parentCanvas;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        EnterAnimation();
    }

    private void OnDisable()
    {
        ExitAnimation();
    }

    public void EnterAnimation()
    {
        _animator.SetBool("IsEnter", true);
    }

    public void ExitAnimation()
    {
        _animator.SetBool("IsEnter", false);
    }

    public void SetActiveParent()
    {
        _parentCanvas.SetActive(false);
    }
}
