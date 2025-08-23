using System.Collections.Generic;
using Gameplay.SlotSystem.Scriptables;
using Gameplay.WheelSystem.Enums;
using UnityEngine;

namespace Gameplay.WheelSystem.Scriptables
{
    [CreateAssetMenu(fileName = "WheelDataSO", menuName = "Data/Wheel/WheelDataSO", order = 0)]
    public class WheelDataSO : ScriptableObject
    {
        public WheelType wheelType;
        public Sprite wheelSprite;
        public Sprite wheelIndicatorSprite;
        public bool isRiskFree;
        public List<BaseRewardSO> wheelItemContentList;
    }
}