using System;
using Core.EventBusSystem.Utils;
using Core.StateSystem.Events;
using Core.StateSystem.Interface;

namespace Core.StateSystem.Base
{
    public abstract class BaseState<TStateType> : IState<TStateType> where TStateType : Enum
    {
        public abstract TStateType StateType { get; }

        public abstract void Start();
        public abstract void End();
        protected void ChangeState(TStateType stateType)
        {
            EventDispatcher.Raise(
                new IStateMachineEvent.OnChangeState<TStateType>(stateType));
        }
    }
}