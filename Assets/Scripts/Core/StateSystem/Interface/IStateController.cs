using System;
using Core.EventBusSystem.Classes;
using Core.StateSystem.Classes;
using Core.StateSystem.Events;

namespace Core.StateSystem.Interface
{
    public interface IStateController<TStateType> where TStateType : Enum
    {
        TStateType CurrentState { get; set; } 
        StateMachine<TStateType> StateMachine { get; set; }
        void InitializeStates();
        void ChangeState(TStateType newStateType, DataTransporter data);
        void StateChanged(TStateType previousStateType, TStateType newStateType);
        EventBinding<IStateMachineEvent<TStateType>.OnChangeState> OnChangeStateBinding { get; set; }
    }
}