using Core.StateSystem.Base;
using Core.StateSystem.Enums;
using UnityEngine;

namespace Core.StateSystem.States.WheelStates
{
    public class WheelState : BaseState<WheelStateType>
    {
        protected WheelState(WheelStateType stateType) : base(stateType)
        {
        }
    }
}