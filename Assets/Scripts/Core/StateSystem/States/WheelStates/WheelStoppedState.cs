using Core.StateSystem.Classes;
using Core.StateSystem.Enums;

namespace Core.StateSystem.States.WheelStates
{
    public class WheelStoppedState : WheelState
    {
        public WheelStoppedState() : base(WheelStateType.Stopped)
        {
        }

        public override void Start(DataTransporter data = null)
        {
            base.Start(data);
            ChangeState(WheelStateType.Collecting, data);
        }
    }
}