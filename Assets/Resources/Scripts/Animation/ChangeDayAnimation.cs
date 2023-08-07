﻿using UnityEngine;
using UnityEngine.UI;

namespace Resources.Scripts.Animation
{
    public class ChangeDayAnimation : MonoBehaviour
    {
        [SerializeField] private DayChanger _dayChanger;
        [SerializeField] private MoneyNewDayAdder moneyNewDayAdder;
        [SerializeField] private Button _activateButton;
        private Animator _animator;
        private Animator _buttonAnim;

        public bool CartIsBroken;

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
            if (!CartIsBroken)
            {
                _dayChanger.DeleteCart();
                _dayChanger.SpawnCart();
            }
        }

        public void SpawnMoney()
        {
            moneyNewDayAdder.AddMoney();
        }

        public void ActiveButton()
        {
            _activateButton.enabled = true;
        }
        
        public void ShowCards()
        {
            _dayChanger.ShowCards();
        }

        
    }
}