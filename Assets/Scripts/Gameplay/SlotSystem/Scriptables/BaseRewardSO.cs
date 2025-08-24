using Gameplay.SlotSystem.Classes;
using Gameplay.SlotSystem.Enums;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.SlotSystem.Scriptables
{
    public abstract class BaseRewardSO : ScriptableObject
    {
        public RewardItemData rewardItemData;
        public RarityType rarityType;
        [Range(0, 100)] public float dropRate;
        public Vector2Int minMaxCount = new(1, 1);   
        
        public int GetRewardCount()
        {
            int rewardCount = 0;
            rewardCount = Random.Range(minMaxCount.x, minMaxCount.y);
            
            return rewardCount; 
        }
    }
}
