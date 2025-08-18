using EventBusSystem.Interfaces;

namespace StateSystem.Events
{
    public interface IStateMachineEvent : IEvent
    { 
        public struct OnStateChanged<TStateType> : IStateMachineEvent 
        {
            public TStateType NewState { get; }
            public TStateType PreviousState { get; }

            public OnStateChanged(TStateType previousState, TStateType newState)
            {
                PreviousState = previousState;
                NewState = newState;
            }
        }

        public struct OnChangeState<TStateType> : IStateMachineEvent
        {
            public TStateType StateType { get; }
            public OnChangeState(TStateType stateType)
            {
                StateType = stateType;
            }
        }
    }
}