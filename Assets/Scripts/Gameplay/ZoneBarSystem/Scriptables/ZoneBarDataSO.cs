using Controllers.Enums;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.ZoneBarSystem.Scriptables
{
    [CreateAssetMenu(fileName = "ZoneBarDataSO", menuName = "Data/General/ZoneBarDataSO", order = 1)]
    public class ZoneBarDataSO : ScriptableObject
    {
        [Header("Zone Backgrounds")]
        [SerializeField] private Sprite _standardZoneBackground;
        [SerializeField] private Sprite _safeZoneBackground;
        [SerializeField] private Sprite _superZoneBackground;
        public Sprite GetZoneBackground(FortuneType eventDataFortuneType)
        {
            switch (eventDataFortuneType)
            {
                case FortuneType.Silver:
                    return _safeZoneBackground;
                case FortuneType.Gold:
                    return _superZoneBackground;
                case FortuneType.Bronze:
                    return _standardZoneBackground;
                default:
                    return null; // Assuming Bronze has no specific background
            }
        }
    }
}