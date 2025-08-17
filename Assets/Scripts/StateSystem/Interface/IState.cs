using System;

namespace StateSystem.Interface
{
    public interface IState<TStateType> where TStateType : Enum
    {
        TStateType StateType { get; }
        void Start();
        void End();
    }
}