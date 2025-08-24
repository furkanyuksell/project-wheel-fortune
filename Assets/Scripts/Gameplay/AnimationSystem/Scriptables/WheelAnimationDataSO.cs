using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.AnimationSystem.Scriptables
{
    [CreateAssetMenu(fileName = "WheelAnimationData", menuName = "Data/Animation/WheelAnimationData")]
    public class WheelAnimationDataSO : BaseAnimationDataSO
    {
        public float wheelMinTurnCount;
        public float spinDuration;
        public Ease spinEase;
    }
}