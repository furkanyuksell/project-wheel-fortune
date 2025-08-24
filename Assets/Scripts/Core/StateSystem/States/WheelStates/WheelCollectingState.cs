using Controllers.MonoBehaviours;
using Core.StateSystem.Classes;
using Core.StateSystem.Enums;
using Gameplay.SlotSystem.Classes;

namespace Core.StateSystem.States.WheelStates
{
    public class WheelCollectingState : WheelState
    {
        private PrizeBarController _prizeBarController;
        public WheelCollectingState(PrizeBarController prizeBarController) : base(WheelStateType.Collecting)
        {
            _prizeBarController = prizeBarController;
        }

        public override void Start(DataTransporter data = null)
        {
            base.Start(data);
            RewardSlotData rewardItemData = data!.Get<RewardSlotData>("reward");
            _prizeBarController.CheckRewardData(rewardItemData);
        }
    }
}