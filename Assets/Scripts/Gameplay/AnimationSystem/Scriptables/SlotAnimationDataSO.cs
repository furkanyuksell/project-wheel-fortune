using DG.Tweening;
using UnityEngine;

namespace Gameplay.AnimationSystem.Scriptables
{
    [CreateAssetMenu(fileName = "SlotAnimationData", menuName = "Data/Animation/SlotAnimationData", order = 1)]
    public class SlotAnimationDataSO : BaseAnimationDataSO
    {
        public float punchScale = 0.3f;
        public float punchDuration = 0.3f;
        public int punchVibrato = 10;
        public float punchElasticity = 1f;
        
        public float incrementDuration = 0.5f;
        public Ease incrementEase = Ease.Linear;
    }
}