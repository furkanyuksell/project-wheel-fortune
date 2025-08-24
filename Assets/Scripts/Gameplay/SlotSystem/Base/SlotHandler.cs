using Core.BaseClasses;
using Core.ObjectPoolSystem.Base;
using Gameplay.SlotSystem.Scriptables;
using UnityEngine;

namespace Gameplay.SlotSystem.Base
{
    public abstract class SlotHandler : PoolableObject
    {
        [Header("References")]
        [SerializeField] private BaseSlotView _slotView;

        #region Privates
        private BaseRewardSO _itemInfo;
        #endregion
        
        public void Prepare(Vector3 viewPos, Vector3 viewRot, Transform itemHolder, BaseRewardSO itemInfo)
        {
            OnActivate(itemHolder);
            transform.localPosition = viewPos;
            transform.localEulerAngles = viewRot;
            _slotView.SetModel(itemInfo);
        }
    }
}