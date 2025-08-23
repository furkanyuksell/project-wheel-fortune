using Gameplay.SlotSystem.Classes;
using Gameplay.SlotSystem.Enums;
using UnityEngine;

namespace Gameplay.SlotSystem.Scriptables
{
    public abstract class BaseRewardSO : ScriptableObject
    {
        public RewardItem rewardItem;
        public RarityType rarityType;
        [Range(0, 100)]
        public float possibilityRatio;
    }
}
