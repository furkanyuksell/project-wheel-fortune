using Controllers.Scriptables;
using Core.StateSystem.Enums;
using Gameplay.SlotSystem.MonoBehaviours;
using Gameplay.WheelSystem.MonoBehaviours;

namespace Core.StateSystem.States.WheelStates
{
    public class WheelPreparation : WheelState
    {
        #region Privates
        private FortuneDataSO _fortuneDataSO;
        #endregion
        
        public WheelPreparation(FortuneDataSO fortuneDataSO) : base(WheelStateType.Preparation)
        {
            _fortuneDataSO = fortuneDataSO;
        }

        public override void Start()
        {
            base.Start();
            
        }
    }
}