using Gameplay.ItemSystem.Classes;
using Gameplay.ItemSystem.Enums;
using UnityEngine;

namespace Gameplay.ItemSystem.Scriptables
{
    public abstract class BaseRewardSO : ScriptableObject
    {
        public RewardItem rewardItem;
        public RarityType rarityType;
        [Range(0, 100)]
        public float possibilityRatio;
    }
}
