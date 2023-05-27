using System;
using UnityEngine;

namespace Resources.Scripts.Animation
{
    public class ChangeDayAnimation : MonoBehaviour
    {
        [SerializeField] private DayChanger _dayChanger;
        [SerializeField] private Wallet _wallet;
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void ChangeDay()
        {
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
    }
}