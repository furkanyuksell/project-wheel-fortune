using Controllers.Base;
using Core.EventBusSystem.Classes;
using Core.EventBusSystem.Utils;
using Core.StateSystem.Classes;
using Core.StateSystem.Enums;
using Core.StateSystem.Events;
using Core.StateSystem.Interface;
using Core.StateSystem.States.WheelStates;
using Gameplay.WheelSystem.MonoBehaviours;
using UnityEngine;

namespace Controllers.MonoBehaviours
{
    public class WheelController : BaseController, IStateController<WheelStateType>
    {
        [Header("References")]
        #region Handlers
        [SerializeField] private WheelHandler _handler;
        #endregion

        #region Controllers
        private GameController _gameController;
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
        public EventBinding<IStateMachineEvent.OnChangeState<WheelStateType>> OnChangeStateBinding { get; set; }
        #endregion

        private void Awake()
        {
            StateMachine = new StateMachine<WheelStateType>(this);
        }

        protected override void ResolveDependencies()
        {
            _gameController = ResolveDependency<GameController>();
        }

        protected override void Register(bool isActive)
        {
            base.Register(isActive);
            if (isActive)
            {
                OnChangeStateBinding = EventDispatcher.Subscribe<IStateMachineEvent.OnChangeState<WheelStateType>>(OnChangeState);
            }
            else
            {
                EventDispatcher.Unsubscribe(OnChangeStateBinding);
                OnChangeStateBinding = null;
            }
        }

        public override void Initialize()
        {
            InitializeStates();
        }

        public void InitializeStates()
        {
            _preparationState = new WheelPreparation(_gameController.FortuneDataSO);
            _readyState = new WheelReadyState();
            _spinningState = new WheelSpinningState();
            _stoppedState = new WheelStoppedState();
            _collectingState = new WheelCollectingState();
            _finishedState = new WheelFinishedState();

            StateMachine.RegisterState(_preparationState);
            StateMachine.RegisterState(_readyState);
            StateMachine.RegisterState(_spinningState);
            StateMachine.RegisterState(_stoppedState);
            StateMachine.RegisterState(_collectingState);
            StateMachine.RegisterState(_finishedState);
        }
        
        public void StartWheel()
        {
            ChangeState(WheelStateType.Preparation);
        }
        
        private void OnChangeState(IStateMachineEvent.OnChangeState<WheelStateType> changeStateEvent)
        {
            ChangeState(changeStateEvent.StateType);
        }

        public void ChangeState(WheelStateType newStateType)
        {
            StateMachine.ChangeState(newStateType);
        }

        public void StateChanged(WheelStateType previousStateType, WheelStateType newStateType)
        {
            CurrentState = newStateType;
            Debug.Log($"Wheel state {previousStateType} changed to: {newStateType}");
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_handler == null)
            {
                _handler = FindObjectOfType<WheelHandler>();
                if (_handler == null) 
                    Debug.LogError("WheelHandler not found in the scene. Please ensure it is present.");
            }
        }
#endif
    }
}