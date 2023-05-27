using System;
using UnityEngine;
using UnityEngine.UI;

namespace Resources.Scripts.Animation
{
    public class ChangeDayAnimation : MonoBehaviour
    {
        [SerializeField] private DayChanger _dayChanger;
        [SerializeField] private Wallet _wallet;
        [SerializeField] private Button _activateButton;
        private Animator _animator;
        private Animator _buttonAnim;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _buttonAnim = _activateButton.gameObject.GetComponent<Animator>();
        }

        public void ChangeDay()
        {
            _activateButton.enabled = false;
            _animator.SetTrigger("ChangeDay");
        }

        public void TrySpawnCart()
        {
            _dayChanger.DeleteCart();
            _dayChanger.SpawnCart();
        }

        public void SpawnMoney()
        {
            _wallet.AddGold(2);
        }

        public void ActiveButton()
        {
            _activateButton.enabled = true;
        }

        
    }
}