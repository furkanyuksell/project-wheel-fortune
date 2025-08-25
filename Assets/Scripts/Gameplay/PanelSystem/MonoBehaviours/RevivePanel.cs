using System;
using Controllers.MonoBehaviours;
using Gameplay.PanelSystem.Base;
using Gameplay.ReviveSystem.Components;
using Gameplay.ReviveSystem.Scriptables;
using UnityEngine;

namespace Gameplay.PanelSystem.MonoBehaviours
{
    public class RevivePanel : BasePanel
    {
        [Header("References")]
        [SerializeField] private Transform _popupTransform;
        [SerializeField] private ReviveButton _reviveButton;
        [SerializeField] private GiveUpButton _giveUpButton;

        #region Privates
        private ReviveController _reviveController;
        #endregion

        public void Prepare(ReviveController reviveController, ReviveDataSO reviveData)
        {
            _reviveController = reviveController;
            _reviveButton.SetOnClickAction(OnReviveButtonClick);
            _reviveButton.SetText(reviveData.reviveCost+"$ REVIVE");
        }

        public void ShowPopup(bool isEnoughCurrency = true)
        {
            _reviveButton.gameObject.SetActive(isEnoughCurrency);
            _popupTransform.gameObject.SetActive(true);
        }

        public void HidePopup()
        {
            _popupTransform.gameObject.SetActive(false);
        }

        private void OnReviveButtonClick()
        {   
            _reviveController.OnRevive();
            HidePopup();
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (!_reviveButton) _reviveButton = GetComponentInChildren<ReviveButton>();
            if (!_giveUpButton) _giveUpButton = GetComponentInChildren<GiveUpButton>();
        }
#endif
    }
}