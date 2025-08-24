using Controllers.Base;
using Gameplay.SlotSystem.Classes;
using Gameplay.SlotSystem.Enums;
using UnityEngine;

namespace Controllers.MonoBehaviours
{
    public class PrizeBarController : BaseController
    {
        public override void Initialize()
        {
        }

        public void CheckRewardData(RewardSlotData rewardSlotData)
        {
            if (rewardSlotData.itemData.rewardType == RewardType.Death)
            {
                Debug.Log("DEATH");
                return;
            }

            GrantReward(rewardSlotData);
        }

        private void GrantReward(RewardSlotData rewardSlotData)
        {
            
        }
    }
}