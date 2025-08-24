using Controllers.MonoBehaviours;
using Core.EventBusSystem.Utils;
using Core.StateSystem.Classes;
using Core.StateSystem.Enums;
using Gameplay.PanelSystem.Events;
using Gameplay.WheelSystem.Events;

namespace Core.StateSystem.States.WheelStates
{
    public class WheelPreparation : WheelState
    {
        #region DI
        private readonly FortuneLevelController _fortuneLevelController;
        #endregion
        
        public WheelPreparation(FortuneLevelController fortuneLevelController) : base(WheelStateType.Preparation)
        {
            _fortuneLevelController = fortuneLevelController;
        }

        public override void Start(DataTransporter data = null)
        {
            base.Start(data);
            EventDispatcher.Raise(new IWheelEvent.OnWheelPreparation(_fortuneLevelController.GetLevel(), _fortuneLevelController.GetFortuneType()));
            ChangeState(WheelStateType.Ready);
        }
    }
}