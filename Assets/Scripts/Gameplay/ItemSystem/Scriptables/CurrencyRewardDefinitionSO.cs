using Gameplay.ItemSystem.Enums;
using UnityEngine;

namespace Gameplay.ItemSystem.Scriptables
{
    [CreateAssetMenu(fileName = "RewardDataSO", menuName = "Data/Wheel Fortune/CurrencyRewardDefinitionSO", order = 0)]
    public class CurrencyRewardDefinitionSO : BaseRewardSO
    {
        public CurrencyType currencyType;
    }
}