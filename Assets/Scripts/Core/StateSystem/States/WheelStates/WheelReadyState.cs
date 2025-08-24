using Core.EventBusSystem.Utils;
using Core.StateSystem.Classes;
using Core.StateSystem.Enums;
using Gameplay.WheelSystem.Events;

namespace Core.StateSystem.States.WheelStates
{
    public class WheelReadyState : WheelState
    {
        public WheelReadyState() : base(WheelStateType.Ready)
        {
        }

        public override void Start(DataTransporter data = null)
        {
            base.Start(data);
            EventDispatcher.Raise(new IWheelEvent.OnWheelReady());
        }
    }
}