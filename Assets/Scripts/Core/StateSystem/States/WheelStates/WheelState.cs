using Core.StateSystem.Base;
using Core.StateSystem.Enums;
using UnityEngine;

namespace Core.StateSystem.States.WheelStates
{
    public class WheelState : BaseState<WheelStateType>
    {
        public WheelState(WheelStateType stateType) : base(stateType)
        {
        }
    }
}