using System;
using System.Collections.Generic;
using Core.EventBusSystem.Utils;
using Core.StateSystem.Events;
using Core.StateSystem.Interface;

namespace Core.StateSystem.Classes
{
    public class StateMachine<TStateType> where TStateType : Enum
    {
        public TStateType CurrentStateType { get; private set; }
        public IState<TStateType> CurrentState { get; private set; }

        private readonly Dictionary<TStateType, IState<TStateType>> _states;
        
        public StateMachine()
        {
            _states = new Dictionary<TStateType, IState<TStateType>>();
        }

        public void RegisterState(IState<TStateType> state)
        {
            if (!_states.TryAdd(state.StateType, state))
                throw new ArgumentException($"State {state.StateType} is already registered.");
        }

        public void ChangeState(TStateType newStateType)
        {
            if (_states.TryGetValue(newStateType, out var newState))
            {
                var previousStateType = CurrentStateType;
                CurrentState?.End();
                CurrentState = newState;
                CurrentStateType = newStateType;

                EventDispatcher.Raise(new IStateMachineEvent.OnStateChanged<TStateType>(previousStateType, newStateType));
                CurrentState.Start();
            }
            else
            {
                throw new ArgumentException($"State {newStateType} is not registered.");
            }
        }

        public T GetState<T>(TStateType stateType) where T : class, IState<TStateType>
        {
            return _states.TryGetValue(stateType, out var state) ? state as T : null;
        }
    }
}