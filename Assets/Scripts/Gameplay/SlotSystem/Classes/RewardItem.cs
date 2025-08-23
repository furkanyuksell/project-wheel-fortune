using System;
using Gameplay.SlotSystem.Enums;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.SlotSystem.Classes
{
    [Serializable]
    public class RewardItem
    {
        public string name;
        public Sprite icon;
        public RewardType rewardType;
    }
}