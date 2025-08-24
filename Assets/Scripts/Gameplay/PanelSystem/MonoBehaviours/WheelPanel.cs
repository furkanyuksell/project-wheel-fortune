using Core.EventBusSystem.Classes;
using Core.EventBusSystem.Utils;
using Gameplay.AnimationSystem.Classes;
using Gameplay.PanelSystem.Base;
using Gameplay.PanelSystem.Events;
using Gameplay.WheelSystem.Classes;
using Gameplay.WheelSystem.Components;
using Gameplay.WheelSystem.Events;
using Gameplay.WheelSystem.MonoBehaviours;
using UnityEngine;

namespace Gameplay.PanelSystem.MonoBehaviours
{
    public class WheelPanel : BasePanel
    {
        #region References
        [Header("References")]
        [SerializeField] private WheelSlotListPresenter _presenter;
        [SerializeField] private SpinButton _spinButton;
        [SerializeField] private Transform _wheelTransform;
        #endregion

        #region Data
        private WheelDataModel _wheelDataModel;
        #endregion

        #region Events
        private EventBinding<IWheelEvent.OnWheelReady> _onWheelReadyBinding;
        #endregion

        #region Animator
        private WheelAnimator _wheelAnimator;
        #endregion

        protected override void Register(bool isActive)
        {
            base.Register(isActive);
            if (isActive)
            {
                _onWheelReadyBinding = EventDispatcher.Subscribe<IWheelEvent.OnWheelReady>(OnWheelReady);
            }
            else
            {
                if (_onWheelReadyBinding != null)
                {
                    EventDispatcher.Unsubscribe(_onWheelReadyBinding);
                    _onWheelReadyBinding = null;
                }
            }
        }

        public void Initialize(WheelDataModel wheelDataModel)
        {
            _wheelDataModel = wheelDataModel;
            _wheelAnimator = new WheelAnimator(_wheelTransform);
            _presenter.Initialize();
            _spinButton.SetOnClickAction(StartWheelSpin);
        }

        protected override void OnPanelPrepare(IWheelEvent.OnWheelPreparation eventData)
        {
            _spinButton.ClickableStatus(false);
            _presenter.Prepare(_wheelDataModel.GetWheelDataSO(eventData.FortuneType));
        }

        private void OnWheelReady(IWheelEvent.OnWheelReady eventData)
        {
            _spinButton.ClickableStatus(true);
        }

        private void StartWheelSpin()
        {
            var result = _presenter.GetSpinResult();
            _wheelAnimator.PlaySpinAnimation(result.Item2);
        }


#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_presenter == null)
            {
                _presenter = GetComponentInChildren<WheelSlotListPresenter>();
                if (_presenter == null)
                {
                    Debug.LogError("WheelListPresenter not found in WheelPanel. Please assign it in the inspector.");
                }
            }
            
            if (_spinButton == null)
            {
                _spinButton = GetComponentInChildren<SpinButton>();
                if (_spinButton == null)
                {
                    Debug.LogError("SpinButton not found in WheelPanel. Please assign it in the inspector.");
                }
            }
        }
#endif
    }
}