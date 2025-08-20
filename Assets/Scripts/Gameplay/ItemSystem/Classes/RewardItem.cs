using System;
using Gameplay.ItemSystem.Enums;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.ItemSystem.Classes
{
    [Serializable]
    public class RewardItem
    {
        public string name;
        public Sprite icon;
        public RewardType rewardType;
    }
}