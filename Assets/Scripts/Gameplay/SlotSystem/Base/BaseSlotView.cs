using Core.BaseClasses;
using Gameplay.SlotSystem.Classes;
using Gameplay.SlotSystem.Components;
using Gameplay.SlotSystem.Scriptables;
using UnityEngine;

namespace Gameplay.SlotSystem.Base
{
    public class BaseSlotView : BaseView<RewardSlotData>
    {
        [SerializeField] private SlotImage _imgSlot;
        [SerializeField] private SlotCountText _txtSlot;

        protected override void Refresh()
        {
            if (_model == null) return;
            
            _imgSlot.SetSprite(_model.itemData.icon);
            _txtSlot.SetText(_model.itemCount.ToString());
        }

        private void OnValidate()
        {
            if (!_imgSlot) _imgSlot = GetComponentInChildren<SlotImage>();
            if (!_txtSlot) _txtSlot = GetComponentInChildren<SlotCountText>();
        }
    }
}