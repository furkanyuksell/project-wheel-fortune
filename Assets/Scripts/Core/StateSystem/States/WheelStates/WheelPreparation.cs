using Controllers.MonoBehaviours;
using Core.EventBusSystem.Utils;
using Core.StateSystem.Enums;
using Gameplay.PanelSystem.Events;

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

        public override void Start()
        {
            base.Start();
            EventDispatcher.Raise(new IPanelEvent.OnPanelPrepare(_fortuneLevelController.GetLevel(), _fortuneLevelController.GetFortuneType()));
            ChangeState(WheelStateType.Ready);
        }
    }
}