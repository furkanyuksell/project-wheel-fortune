using Controllers.Base;
using Core.EventBusSystem.Classes;
using Core.EventBusSystem.Utils;
using Core.StateSystem.Classes;
using Core.StateSystem.Enums;
using Core.StateSystem.Events;
using Core.StateSystem.Interface;
using Core.StateSystem.States.WheelStates;
using Gameplay.PanelSystem.MonoBehaviours;
using Gameplay.SlotSystem.Classes;
using Gameplay.WheelSystem.Classes;
using Gameplay.WheelSystem.MonoBehaviours;
using UnityEngine;

namespace Controllers.MonoBehaviours
{
    public class WheelController : BaseController, IStateController<WheelStateType>
    {
        #region References
        [Header("References")]
        [SerializeField] private WheelPanel _wheelPanel;
        #endregion
        
        #region Data
        private WheelDataModel _wheelDataModel;
        #endregion
        
        #region Controllers
        private GameController _gameController;
        private FortuneLevelController _fortuneLevelController;
        private PrizeBarController _prizeBarController;
        #endregion

        #region State Machine Implamentation
        public StateMachine<WheelStateType> StateMachine { get; set; }
        public WheelStateType CurrentState { get; set; }
        private WheelPreparation _preparationState;
        private WheelReadyState _readyState;
        private WheelSpinningState _spinningState;
        private WheelStoppedState _stoppedState;
        private WheelCollectingState _collectingState;
        private WheelFinishedState _finishedState;
        #endregion

        #region Events
        public EventBinding<IStateMachineEvent<WheelStateType>.OnChangeState> OnChangeStateBinding { get; set; }
        #endregion

        private void Awake()
        {
            StateMachine = new StateMachine<WheelStateType>(this);
        }

        protected override void ResolveDependencies()
        {
            _gameController = ResolveDependency<GameController>();
            _fortuneLevelController = ResolveDependency<FortuneLevelController>();
            _prizeBarController = ResolveDependency<PrizeBarController>();
        }

        protected override void Register(bool isActive)
        {
            base.Register(isActive);
            if (isActive)
            {
                OnChangeStateBinding = EventDispatcher.Subscribe<IStateMachineEvent<WheelStateType>.OnChangeState>(OnChangeState);
            }
            else
            {
                EventDispatcher.Unsubscribe(OnChangeStateBinding);
                OnChangeStateBinding = null;
            }
        }

        public override void Initialize()
        {
            InitializeData();
            InitializeStates();
        }

        private void InitializeData()
        {
            _wheelDataModel = new WheelDataModel();
            _wheelPanel.Initialize(_wheelDataModel);
        }

        public void InitializeStates()
        {
            _preparationState = new WheelPreparation(_fortuneLevelController);
            _readyState = new WheelReadyState();
            _spinningState = new WheelSpinningState();
            _stoppedState = new WheelStoppedState();
            _collectingState = new WheelCollectingState(_prizeBarController);
            _finishedState = new WheelFinishedState();

            StateMachine.RegisterState(_preparationState);
            StateMachine.RegisterState(_readyState);
            StateMachine.RegisterState(_spinningState);
            StateMachine.RegisterState(_stoppedState);
            StateMachine.RegisterState(_collectingState);
            StateMachine.RegisterState(_finishedState);
        }
        
        public void PrepareWheel()
        {
            ChangeState(WheelStateType.Preparation);
        }
        
        private void OnChangeState(IStateMachineEvent<WheelStateType>.OnChangeState eventData)
        {
            ChangeState(eventData.StateType, eventData.Data);
        }

        public void ChangeState(WheelStateType newStateType, DataTransporter data = null)
        {
            StateMachine.ChangeState(newStateType, data);
        }

        public void StateChanged(WheelStateType previousStateType, WheelStateType newStateType)
        {
            CurrentState = newStateType;
            Debug.Log($"Wheel state {previousStateType} changed to: {newStateType}");
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_wheelPanel == null)
            {
                _wheelPanel = FindObjectOfType<WheelPanel>();
                if (_wheelPanel == null) 
                    Debug.LogError("WheelHandler not found in the scene. Please ensure it is present.");
            }
        }
#endif
    }
}