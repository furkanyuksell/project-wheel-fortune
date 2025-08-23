using Core.StateSystem.Enums;

namespace Core.StateSystem.States.WheelStates
{
    public class WheelPreparation : WheelState
    {
        public WheelPreparation() : base(WheelStateType.Preparation)
        {
        }

        public override void Start()
        {
            base.Start();
            
        }
    }
}