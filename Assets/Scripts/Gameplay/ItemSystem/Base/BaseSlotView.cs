using Gameplay.ItemSystem.Scriptables;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Gameplay.ItemSystem.Base
{
    public class BaseSlotView : BaseView<RewardDefinitionSO>
    {
        [SerializeField] private Image _iconImage;
        [SerializeField] private TextMeshProUGUI _nameText;

        protected override void Refresh()
        {
            if (_model != null) return;
            
            _iconImage.sprite = _model.rewardItem.icon;
            _nameText.text = string.Empty;
        }
        
    }
}