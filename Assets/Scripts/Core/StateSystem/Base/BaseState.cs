using System;
using Core.EventBusSystem.Utils;
using Core.StateSystem.Events;
using Core.StateSystem.Interface;
using UnityEngine;

namespace Core.StateSystem.Base
{
    public abstract class BaseState<TStateType> : IState<TStateType> where TStateType : Enum
    {
        public TStateType StateType { get; private set; }
        public Action<TStateType> OnChangeState { get; set; }
        protected BaseState(TStateType stateType)
        {
            StateType = stateType;
        }

        public virtual void Start()
        {
            Debug.Log($"{GetType().Name} Started");
        }
        public virtual void End()
        {
            Debug.Log($"{GetType().Name} Ended");
        }

        protected void ChangeState(TStateType stateType)
        {
            EventDispatcher.Raise(
                new IStateMachineEvent.OnChangeState<TStateType>(stateType));
        }
    }
}