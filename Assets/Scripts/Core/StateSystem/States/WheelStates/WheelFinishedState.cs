using Controllers.MonoBehaviours;
using Core.StateSystem.Classes;
using Core.StateSystem.Enums;

namespace Core.StateSystem.States.WheelStates
{
    public class WheelFinishedState : WheelState
    {
        private readonly FortuneLevelController _fortuneLevelController;
        private readonly WheelController _wheelController;
        public WheelFinishedState(FortuneLevelController fortuneLevelController, WheelController wheelController) : base(WheelStateType.Finished)
        {
            _fortuneLevelController = fortuneLevelController;
            _wheelController = wheelController;
        }

        public override void Start(DataTransporter data = null)
        {
            base.Start(data);
            _fortuneLevelController.IncreaseLevel();
            _wheelController.ResetWheel();
            ChangeState(WheelStateType.Preparation);
        }
    }
}