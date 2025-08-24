using Gameplay.PanelSystem.Base;
using Gameplay.PrizeBarSystem.MonoBehaviours;
using Gameplay.SlotSystem.Classes;
using UnityEngine;

namespace Gameplay.PanelSystem.MonoBehaviours
{
    public class PrizeBarPanel : BasePanel
    {
        [Header("References")]
        [SerializeField] private PrizeBarSlotListPresenter _presenter;
        
        public void Initialize()
        {
            _presenter.Initialize();
        }
        
        public void RewardGranted(RewardSlotData rewardSlotData)
        {
            _presenter.AddReward(rewardSlotData);
        }

#if UNITY_EDITOR
        
        private void OnValidate()
        {
            if (!_presenter)
            {
                _presenter = GetComponentInChildren<PrizeBarSlotListPresenter>();
                if (!_presenter)
                {
                    Debug.LogError("PrizeBarSlotListPresenter not found in children of PrizeBarPanel.");
                }
            }
            
        }
#endif

    }
}