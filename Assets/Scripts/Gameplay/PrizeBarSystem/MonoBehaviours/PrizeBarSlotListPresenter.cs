using System;
using System.Collections;
using Controllers.Events;
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
        [Header("References")]
        [SerializeField] private Transform _slotParent;
        
        public override void Initialize()
        {
            base.Initialize();
            _slotType = SlotType.Prize;
        }

        public void AddReward(RewardSlotData rewardSlotData)
        {
            if (CheckRewardExists(rewardSlotData, out var baseSlotHandler))
            {
                baseSlotHandler.UpdateCount(rewardSlotData.itemCount);
            }
            else
            {
                baseSlotHandler = _slotPool.GetPooledItem((int)_slotType);
                baseSlotHandler.Prepare(_slotParent, rewardSlotData);
                _slots.Add(baseSlotHandler as PrizeSlotHandler);
            }
            
            StartCoroutine(SpawnIconAfterLayoutUpdate(rewardSlotData, baseSlotHandler));
        }

        private bool CheckRewardExists(RewardSlotData rewardSlotData, out BaseSlotHandler baseSlotHandler)
        {
            baseSlotHandler = null;
            foreach (var slot in _slots)
            {
                if (slot.rewardSlotData.itemData.name == rewardSlotData.itemData.name)
                {
                    baseSlotHandler = slot;
                    return true;
                }
            }
            return false;
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

        public void AddCurrencies()
        {
            int amount = 0;
            foreach (var prizeSlotHandler in _slots)
            {
                if (prizeSlotHandler.rewardSlotData.itemData.rewardType == RewardType.Gold)
                {
                    amount += prizeSlotHandler.rewardSlotData.itemCount * 5;   
                }
                else if (prizeSlotHandler.rewardSlotData.itemData.rewardType == RewardType.Cash)
                {
                    amount += prizeSlotHandler.rewardSlotData.itemCount * 2;   
                }
            }

            EventDispatcher.Raise(new IControllerEvent.OnAddCurrency(amount));
        }
    }
}