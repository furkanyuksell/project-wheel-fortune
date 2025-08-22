using Core.StateSystem.Enums;

namespace Core.StateSystem.States.WheelStates
{
    public class WheelStoppedState : WheelState
    {
        public WheelStoppedState() : base(WheelStateType.Stopped)
        {
        }
    }
}