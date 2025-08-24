using Core.BaseClasses;
using Core.ObjectPoolSystem.Base;
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
        #endregion

        #region Publics
        public BaseRewardSO rewardDataSO => _rewardDataSO;
        public RewardSlotData rewardSlotData => _rewardSlotData;
        #endregion
        
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
    }
}