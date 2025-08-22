using System;
using Gameplay.ItemSystem.Components;
using Gameplay.ItemSystem.Scriptables;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Gameplay.ItemSystem.Base
{
    public class BaseSlotView : BaseView<RewardDefinitionSO>
    {
        [SerializeField] private SlotImage _imgSlot;
        [SerializeField] private SlotCountText _txtSlot;

        protected override void Refresh()
        {
            if (_model != null) return;
            
            _imgSlot.SetSprite(_model.rewardItem.icon);
        }


        private void OnValidate()
        {
            if (!_imgSlot) _imgSlot = GetComponentInChildren<SlotImage>();
            if (!_txtSlot) _txtSlot = GetComponentInChildren<SlotCountText>();
        }
    }
}