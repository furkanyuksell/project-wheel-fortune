using System;
using Core.BaseClasses;
using Core.ObjectPoolSystem.Base;
using DG.Tweening;
using Gameplay.AnimationSystem.Classes;
using Gameplay.SlotSystem.Classes;
using Gameplay.SlotSystem.Scriptables;
using UnityEngine;

namespace Gameplay.SlotSystem.Base
{
    public abstract class BaseSlotHandler : PoolableObject
    {
        [Header("References")]
        [SerializeField] private BaseSlotView _slotView;

        #region Privates
        private BaseRewardSO _rewardDataSO;
        private RewardSlotData _rewardSlotData;
        private SlotAnimator _slotAnimator;
        #endregion

        #region Publics
        public BaseRewardSO rewardDataSO => _rewardDataSO;
        public RewardSlotData rewardSlotData => _rewardSlotData;
        public Transform iconTarget => _slotView.imgSlot.transform;
        #endregion

        private void Start()
        {
            _slotAnimator = new SlotAnimator(iconTarget);
        }

        public void Prepare(Vector3 viewPos, Vector3 viewRot, Transform itemHolder, BaseRewardSO rewardDataSO)
        {
            OnActivate(itemHolder);
            transform.localPosition = viewPos;
            transform.localEulerAngles = viewRot;
            _rewardDataSO = rewardDataSO;

            _rewardSlotData = new RewardSlotData
            {
                itemData = _rewardDataSO.rewardItemData,
                itemCount = _rewardDataSO.GetRewardCount()
            };
            _slotView.SetModel(_rewardSlotData);
        }

        public void Prepare(Transform slotParent, RewardSlotData slotData)
        {
            OnActivate(slotParent);
            _rewardSlotData = new RewardSlotData
            {
                itemData = slotData.itemData,
                itemCount = 0
            };

            if (_slotView != null) 
                _slotView.SetModel(_rewardSlotData);
        }

        public void UpdateCount(int itemCount)
        {
            AnimateAdd(_rewardSlotData.itemCount, itemCount);
            RewardGrantAnim();
            _rewardSlotData.itemCount += itemCount;
        }
        
        private void AnimateAdd(int count, int value)
        {
            if (value == 0) return;
            _slotAnimator.IncrementCount(count, value, _slotView.txtSlot);
        }

        private void RewardGrantAnim()
        {
            _slotAnimator.PlayRewardGrantPunch();
        }
    }
}