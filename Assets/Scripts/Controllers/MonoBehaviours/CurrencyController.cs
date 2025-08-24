using System;
using Controllers.Base;
using Controllers.Events;
using Core.EventBusSystem.Classes;
using Core.EventBusSystem.Utils;
using Gameplay.CurrencySystem.MonoBehaviours;
using UnityEngine;

namespace Controllers.MonoBehaviours
{
    public class CurrencyController : BaseController
    {
        [Header("References")]
        [SerializeField] private CurrencyPanel _currencyPanel;
        
        #region Events
        private EventBinding<IControllerEvent.OnAddCurrency> _addCurrencyBinding;
        #endregion

        #region PlayerPrefs

        private int Currency
        {
            get => PlayerPrefs.GetInt("Currency", 0);
            set => PlayerPrefs.SetInt("Currency", value);
        }

        #endregion
        
        public override void Initialize()
        {
            _currencyPanel.SetCurrencyText(Currency.ToString());   
        }

        protected override void Register(bool isActive)
        {
            base.Register(isActive);
            if (isActive)
            {
                _addCurrencyBinding = EventDispatcher.Subscribe<IControllerEvent.OnAddCurrency>(OnAddCurrency);
            }
            else
            {
                EventDispatcher.Unsubscribe(_addCurrencyBinding);
                _addCurrencyBinding = null;
            }
        }

        private void OnAddCurrency(IControllerEvent.OnAddCurrency eventData)
        {
            IncreaseCurrency(eventData.Amount);
        }

        public void SetCurrency(int currency)
        {
            Currency = currency;
            _currencyPanel.SetCurrencyText(Currency.ToString());
        }
        
        public int GetCurrency()
        {
            return Currency;
        }
        
        public void IncreaseCurrency(int amount)
        {
            Currency += amount;
            _currencyPanel.SetCurrencyText(Currency.ToString());
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_currencyPanel == null)
            {
                _currencyPanel = FindObjectOfType<CurrencyPanel>();
            }
        }
#endif
    }
}