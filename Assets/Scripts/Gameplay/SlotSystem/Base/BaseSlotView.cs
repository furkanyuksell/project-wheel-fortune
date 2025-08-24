using Core.BaseClasses;
using Gameplay.SlotSystem.Components;
using Gameplay.SlotSystem.Scriptables;
using UnityEngine;

namespace Gameplay.SlotSystem.Base
{
    public class BaseSlotView : BaseView<BaseRewardSO>
    {
        [SerializeField] private SlotImage _imgSlot;
        [SerializeField] private SlotCountText _txtSlot;

        protected override void Refresh()
        {
            if (_model == null) return;
            
            _imgSlot.SetSprite(_model.rewardItem.icon);
            _txtSlot.SetText(_model.GetRewardCount().ToString());
        }


        public void SetCount(int rewardCount)
        {
        }

        private void OnValidate()
        {
            if (!_imgSlot) _imgSlot = GetComponentInChildren<SlotImage>();
            if (!_txtSlot) _txtSlot = GetComponentInChildren<SlotCountText>();
        }
    }
}