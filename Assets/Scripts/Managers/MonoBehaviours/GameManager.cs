using DISystem.Base;
using EventBusSystem.Classes;
using EventBusSystem.Utils;
using StateSystem.Classes;
using StateSystem.Enums;
using StateSystem.Events;
using StateSystem.States.GameStates;
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
        private StateMachine<GameStateType> _gameStateMachine;
        private AppStartState _appStartState;
        private MainMenuState _mainMenuState;
        private LoadGameplayState _loadGameplayState;
        private PlayState _playState;
        
        #endregion

        #region Events

        private EventBinding<IStateMachineEvent.OnStateChanged<GameStateType>> _onStateChangedBinding;
        private EventBinding<IStateMachineEvent.OnChangeState<GameStateType>> _onChangeStateBinding;

        #endregion
        
        #region Unity Methods

        private void Awake()
        {
            _gameStateMachine = new StateMachine<GameStateType>();
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
                _onChangeStateBinding = EventDispatcher.Subscribe<IStateMachineEvent.OnChangeState<GameStateType>>(OnChangeState);
            }
            else
            {
                EventDispatcher.Unsubscribe(_onStateChangedBinding);
                _onStateChangedBinding = null;
                
                EventDispatcher.Unsubscribe(_onChangeStateBinding);
                _onStateChangedBinding = null;
            }
        }

        #endregion


        private void InitializeStates()
        {
            _appStartState = new AppStartState();
            _gameStateMachine.RegisterState(_appStartState);
            
            _mainMenuState = new MainMenuState();
            _gameStateMachine.RegisterState(_mainMenuState);
            
            _loadGameplayState = new LoadGameplayState();
            _gameStateMachine.RegisterState(_loadGameplayState);

            ChangeGameState(GameStateType.AppStart);
        }

        private void OnChangeState(IStateMachineEvent.OnChangeState<GameStateType> onChangeState)
        {
            ChangeGameState(onChangeState.StateType);
        }

        private void ChangeGameState(GameStateType stateType)
        {
            _gameStateMachine.ChangeState(stateType);
        }

        private void OnStateChangedHandler(IStateMachineEvent.OnStateChanged<GameStateType> stateArgs)
        {
            currentGameStateTypeType = stateArgs.NewState;
            Debug.Log($"GameManager: {stateArgs.PreviousState} State changed to {currentGameStateTypeType}");
        }
    }
}
