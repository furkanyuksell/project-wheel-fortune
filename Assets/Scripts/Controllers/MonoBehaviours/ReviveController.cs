using System;
using Controllers.Base;
using Core.StateSystem.Enums;
using Gameplay.PanelSystem.MonoBehaviours;
using Gameplay.ReviveSystem.Scriptables;
using Gameplay.SlotSystem.Classes;
using UnityEngine;

namespace Controllers.MonoBehaviours
{
    public class ReviveController : BaseController
    {
        [Header("References")]
        [SerializeField] private RevivePanel _revivePanel;
        [SerializeField] private ReviveDataSO _reviveData;

        #region DI
        private CurrencyController _currencyController;
        private WheelController _wheelController;
        #endregion
        
        public override void Initialize()
        {
            _revivePanel.Prepare(this, _reviveData);
        }

        protected override void ResolveDependencies()
        {
            _currencyController = ResolveDependency<CurrencyController>();
            _wheelController = ResolveDependency<WheelController>();
        }

        public void ShowRevivePanel()
        {
            _revivePanel.ShowPopup(_currencyController.IsEnoughCurrency(_reviveData.reviveCost));   
        }
        
        public void OnRevive()
        {
            _currencyController.SpendCurrency(_reviveData.reviveCost);
            _wheelController.ChangeState(WheelStateType.Finished);
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_revivePanel == null) 
                _revivePanel = FindObjectOfType<RevivePanel>();
        }
#endif
    }
}