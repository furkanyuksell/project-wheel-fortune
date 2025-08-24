using UnityEngine;

namespace Gameplay.IconSpawnSystem.Scriptables
{
    [CreateAssetMenu(fileName = "IconSpawnSystemData", menuName = "Data/Icon/Create Icon Spawn System Data")]
    public class IconSpawnSystemDataSO : ScriptableObject
    {
        [Header("Visual Variables")]
        public float initialScalePower = 1.35f;
        public float seperationPowerPercent = 0.25f;
        public float initialRotationRandomizerValue = 180f;
        public float targetReachedScalePower = 0.4f;
        public float targetReachedScaleDuration = 0.3f;
        public int maxIconSpawnCount = 10;
        public float iconsMinSeperationRange = 250f;
        public float iconsMaxSeperationRange = 400f;
        public float iconsSeperationDurationMultiplier = 0.3f;
        public float iconsMovementDuration = 0.65f;
        public float animatedCurrencyUpdateDuration = 0.65f;
        public float animatedCurrencyUpdateDelay = 0.75f;
    }
}