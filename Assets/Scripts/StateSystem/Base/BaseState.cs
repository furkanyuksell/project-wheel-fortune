using System;
using StateSystem.Interface;

namespace StateSystem.Base
{
    public abstract class BaseState<TStateType> : IState<TStateType> where TStateType : Enum
    {
        public abstract TStateType StateType { get; }

        public abstract void Start();
        public abstract void End();
    }
}