using System;
using Core.EventBusSystem.Interfaces;

namespace Core.StateSystem.Events
{
    public interface IStateMachineEvent : IEvent
    { 
        public struct OnChangeState<TStateType> : IStateMachineEvent where TStateType : Enum
        {
            public TStateType StateType { get; }
            public OnChangeState(TStateType stateType)
            {
                StateType = stateType;
            }
        }
    }
}