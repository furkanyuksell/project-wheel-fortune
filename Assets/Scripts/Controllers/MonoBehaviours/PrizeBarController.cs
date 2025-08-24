using Controllers.Base;
using Core.EventBusSystem.Utils;
using Gameplay.IconSpawnSystem.Events;
using Gameplay.PanelSystem.MonoBehaviours;
using Gameplay.SlotSystem.Classes;
using Gameplay.SlotSystem.Enums;
using UnityEngine;

namespace Controllers.MonoBehaviours
{
    public class PrizeBarController : BaseController
    {
        [Header("References")]
        [SerializeField] private PrizeBarPanel _prizeBarPanel;

        #region Privates
        private ReviveController _reviveController;
        #endregion

        protected override void ResolveDependencies()
        {
            _reviveController = ResolveDependency<ReviveController>();
        }

        public override void Initialize()
        {
            _prizeBarPanel.Initialize();
        }

        public void CheckRewardData(RewardSlotData rewardSlotData)
        {
            if (rewardSlotData.itemData.rewardType == RewardType.Death)
            {
                _reviveController.ShowRevivePanel();
                return;
            }
    
            GrantReward(rewardSlotData);
        }

        private void GrantReward(RewardSlotData rewardSlotData)
        {
            _prizeBarPanel.RewardGranted(rewardSlotData);
        }
        
#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_prizeBarPanel == null)
            {
                _prizeBarPanel = FindObjectOfType<PrizeBarPanel>();
            }
        }
#endif
    }
}