using DISystem.Base;
using EventBusSystem.Classes;
using EventBusSystem.Utils;
using StateSystem.Classes;
using StateSystem.Enums;
using StateSystem.Events;
using UnityEngine;

namespace Managers.MonoBehaviours
{
    public class GameManager : ContextDependentBehaviour
    {
        #region Variables
        [Header("Game State")]
        [SerializeField] private GameStateType currentGameStateTypeType = GameStateType.None;
        #endregion

        #region States
        private StateMachine<GameStateType> _stateMachine;
        private AppStartState _appStartState;
        #endregion

        #region Events

        private EventBinding<IStateMachineEvent.OnStateChanged<GameStateType>> _onStateChangedBinding;

        #endregion
        
        #region Unity Methods

        private void Awake()
        {
            _stateMachine = new StateMachine<GameStateType>();
        }

        public void Start()
        {
            InitializeStates();
        }

        protected override void Register(bool isActive)
        {
            base.Register(isActive);
            if(isActive)
            {
                _onStateChangedBinding = EventDispatcher.Subscribe<IStateMachineEvent.OnStateChanged<GameStateType>>(OnStateChangedHandler);
            }
            else
            {
                EventDispatcher.Unsubscribe(_onStateChangedBinding);
            }
        }

        private void OnStateChangedHandler(IStateMachineEvent.OnStateChanged<GameStateType> stateArgs)
        {
            currentGameStateTypeType = stateArgs.NewState;
            Debug.Log($"GameManager: {stateArgs.PreviousState} State changed to {currentGameStateTypeType}");
        }

        #endregion


        private void InitializeStates()
        {
            _stateMachine.RegisterState(new AppStartState());
            
            _stateMachine.ChangeState(GameStateType.OnAppStart);
        }
        
    }
}
