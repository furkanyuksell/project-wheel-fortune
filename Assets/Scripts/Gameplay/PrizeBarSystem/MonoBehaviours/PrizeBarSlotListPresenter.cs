using System.Collections;
using Core.BaseClasses;
using Core.EventBusSystem.Utils;
using Gameplay.IconSpawnSystem.Events;
using Gameplay.SlotSystem.Base;
using Gameplay.SlotSystem.Classes;
using Gameplay.SlotSystem.Enums;
using Gameplay.SlotSystem.MonoBehaviours;
using UnityEngine;

namespace Gameplay.PrizeBarSystem.MonoBehaviours
{
    public class PrizeBarSlotListPresenter : BaseSlotListPresenter<PrizeSlotHandler>
    {
        [SerializeField] private Transform _slotParent;
        
        public override void Initialize()
        {
            base.Initialize();
            _slotType = SlotType.Prize;
        }

        public void AddReward(RewardSlotData rewardSlotData)
        {
            BaseSlotHandler baseSlotHandler = _slotPool.GetPooledItem((int)_slotType);
            baseSlotHandler.Prepare(_slotParent, rewardSlotData);
            _slots.Add(baseSlotHandler as PrizeSlotHandler);
            
            StartCoroutine(SpawnIconAfterLayoutUpdate(rewardSlotData, baseSlotHandler));
        }

        private IEnumerator SpawnIconAfterLayoutUpdate(RewardSlotData rewardSlotData, BaseSlotHandler baseSlotHandler)
        {
            yield return null;
            EventDispatcher.Raise(new ISpawnIconEvent.OnSpawnIcon(
                rewardSlotData.itemData.icon,
                Vector3.zero,
                baseSlotHandler.iconTarget.transform.position
            ));
        }

    }
}