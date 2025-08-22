using Core.EventBusSystem.Classes;
using Core.EventBusSystem.Utils;
using Core.StateSystem.Classes;
using Core.StateSystem.Enums;
using Core.StateSystem.Events;
using Core.StateSystem.Interface;
using Core.StateSystem.States.GameStates;
using Managers.Base;
using UnityEngine;
using UnityEngine.Serialization;

namespace Managers.MonoBehaviours
{
    public class GameManager : BaseManager, IStateController<GameStateType>
    {
        #region Variables
        public StateMachine<GameStateType> StateMachine { get; set; }
        public GameStateType CurrentState { get; set; }
        #endregion

        #region States
        private AppStartState _appStartState;
        private MainMenuState _mainMenuState;
        private LoadGameplayState _loadGameplayState;
        private PlayState _playState;
        #endregion

        #region Events

        public EventBinding<IStateMachineEvent.OnChangeState<GameStateType>> OnChangeStateBinding { get; set; }

        #endregion
        
        #region Unity Methods

        private void Awake()
        {
            StateMachine = new StateMachine<GameStateType>(this);
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
                OnChangeStateBinding = EventDispatcher.Subscribe<IStateMachineEvent.OnChangeState<GameStateType>>(OnChangeState);
            }
            else
            {
                EventDispatcher.Unsubscribe(OnChangeStateBinding);
                OnChangeStateBinding = null;
            }
        }

        #endregion


        public void InitializeStates()
        {
            _appStartState = new AppStartState();
            _mainMenuState = new MainMenuState();
            _loadGameplayState = new LoadGameplayState();
            _playState = new PlayState();
            
            
            StateMachine.RegisterState(_appStartState);
            StateMachine.RegisterState(_mainMenuState);
            StateMachine.RegisterState(_loadGameplayState);
            StateMachine.RegisterState(_playState);

            ChangeState(GameStateType.AppStart);
        }

        private void OnChangeState(IStateMachineEvent.OnChangeState<GameStateType> onChangeState)
        {
            ChangeState(onChangeState.StateType);
        }

        public void ChangeState(GameStateType stateType)
        {
            StateMachine.ChangeState(stateType);
        }

        public void StateChanged(GameStateType previousStateType, GameStateType newStateType) 
        {
            CurrentState = newStateType;
            Debug.Log($"Game state {previousStateType} changed to: {newStateType}");
        }
    }
}
