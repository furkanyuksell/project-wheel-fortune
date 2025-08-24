using System.Collections.Generic;
using Controllers.Enums;
using Gameplay.SlotSystem.Scriptables;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.WheelSystem.Scriptables
{
    [CreateAssetMenu(fileName = "WheelDataSO", menuName = "Data/Wheel/WheelDataSO", order = 0)]
    public class WheelDataSO : ScriptableObject
    {
        public FortuneType fortuneType;
        public Sprite wheelSprite;
        public Sprite wheelIndicatorSprite;
        public int wheelContainableSliceCount;
        public List<BaseRewardSO> wheelItemContentList;
        
        
        public BaseRewardSO GetRandomItem()
        {
            float totalRatio = 0;
            foreach (var itemDataSo in wheelItemContentList)
            {
                totalRatio += itemDataSo.dropRate;
            }

            float randomValue = Random.Range(0, totalRatio);
            float currentRatio = 0;
            foreach (var rewardSO in wheelItemContentList)
            {
                currentRatio += rewardSO.dropRate;
                if (randomValue <= currentRatio)
                {
                    return rewardSO;
                }
            }

            return null;
        }
    }
}