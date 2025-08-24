using Controllers.Base;
using Core.EventBusSystem.Utils;
using Gameplay.IconSpawnSystem.Events;
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
            EventDispatcher.Raise(new ISpawnIconEvent.OnSpawnIcon(
                rewardSlotData.itemData.icon,
                Vector3.zero, // Assuming spawn position is not used here
                transform.position
            ));
        }
    }
}