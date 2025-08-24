using DG.Tweening;
using UnityEngine;

namespace Gameplay.AnimationSystem.Scriptables
{
    [CreateAssetMenu (fileName = "ZoneBarAnimationDataSO", menuName = "Data/Animation/ZoneBarAnimationDataSO", order = 0)]
    public class ZoneBarAnimationDataSO : BaseAnimationDataSO
    {
        public float zoneBarInterval = 140;
        public float duration = 0.5f;
        public Ease ease = Ease.InSine;
    }
}