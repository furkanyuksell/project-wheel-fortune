using System;
using Core.StateSystem.Classes;

namespace Core.StateSystem.Interface
{
    public interface IState<TStateType> where TStateType : Enum
    {
        TStateType StateType { get; }
        void Start(DataTransporter data);
        void End();
    }
}