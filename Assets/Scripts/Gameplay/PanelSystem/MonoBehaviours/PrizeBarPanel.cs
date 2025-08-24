using System;
using System.Collections;
using Controllers.Enums;
using Controllers.MonoBehaviours;
using Core.EventBusSystem.Utils;
using Core.StateSystem.Enums;
using Core.StateSystem.Events;
using Gameplay.PanelSystem.Base;
using Gameplay.PrizeBarSystem.Components;
using Gameplay.PrizeBarSystem.MonoBehaviours;
using Gameplay.SlotSystem.Classes;
using Gameplay.WheelSystem.Events;
using UnityEngine;

namespace Gameplay.PanelSystem.MonoBehaviours
{
    public class PrizeBarPanel : BasePanel
    {
        [Header("References")]
        [SerializeField] private PrizeBarSlotListPresenter _presenter;
        [SerializeField] private ExitButton _exitButton;

        public void Initialize()
        {
            _presenter.Initialize();
            _exitButton.SetOnClickAction(OnAddCurrencies);
        }

        protected override void OnPanelPrepare(IWheelEvent.OnWheelPreparation eventData)
        {
            base.OnPanelPrepare(eventData);
            _exitButton.gameObject.SetActive(eventData.FortuneType != FortuneType.Bronze);
        }

        public void RewardGranted(RewardSlotData rewardSlotData)
        {
            _presenter.AddReward(rewardSlotData);

            StartCoroutine(FinishedState());
        }

        private IEnumerator FinishedState()
        {
            yield return null; // for preventing immediate state change
            EventDispatcher.Raise(new IStateMachineEvent<WheelStateType>.OnChangeState(WheelStateType.Finished));
        }
        
        private void OnAddCurrencies()
        {
            _presenter.AddCurrencies();   
        }

#if UNITY_EDITOR
        
        private void OnValidate()
        {
            if (!_presenter)
            {
                _presenter = GetComponentInChildren<PrizeBarSlotListPresenter>();
                if (!_presenter)
                {
                    Debug.LogError("PrizeBarSlotListPresenter not found in children of PrizeBarPanel.");
                }
            }
            
            if (!_exitButton)
            {
                _exitButton = GetComponentInChildren<ExitButton>();
                if (!_exitButton)
                {
                    Debug.LogError("ExitButton not found in children of PrizeBarPanel.");
                }
            }
        }
#endif

    }
}