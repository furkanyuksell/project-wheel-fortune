using Core.EventBusSystem.Utils;
using Core.StateSystem.Enums;
using Gameplay.WheelSystem.Events;

namespace Core.StateSystem.States.WheelStates
{
    public class WheelReadyState : WheelState
    {
        public WheelReadyState() : base(WheelStateType.Ready)
        {
        }

        public override void Start()
        {
            base.Start();
            EventDispatcher.Raise(new IWheelEvent.OnWheelReady());
        }
    }
}