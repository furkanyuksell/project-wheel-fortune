using System;
using Core.EventBusSystem.Interfaces;
using Core.StateSystem.Classes;

namespace Core.StateSystem.Events
{
    public interface IStateMachineEvent<TStateType> : IEvent where TStateType : Enum
    { 
        public struct OnChangeState : IStateMachineEvent<TStateType>
        {
            public TStateType StateType { get; }
            public DataTransporter Data { get; }
            public OnChangeState(TStateType stateType, DataTransporter data = null)
            {
                StateType = stateType;
                Data = data ?? new DataTransporter();
            }
        }
    }
}