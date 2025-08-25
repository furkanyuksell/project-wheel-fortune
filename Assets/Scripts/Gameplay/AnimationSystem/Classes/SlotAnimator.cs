using System;
using DG.Tweening;
using Gameplay.AnimationSystem.Base;
using Gameplay.AnimationSystem.Scriptables;
using Gameplay.SlotSystem.Components;
using UnityEngine;

namespace Gameplay.AnimationSystem.Classes
{
    public class SlotAnimator : BaseAnimator<SlotAnimationDataSO>
    {
        private Tween _incrementTween;
        public SlotAnimator(Transform transform) : base(transform)
        {
            _data = Resources.Load<SlotAnimationDataSO>("Scriptables/Animation/SlotAnimationData");
        }

        public void PlayRewardGrantPunch()
        {
            PunchAnimation(Vector3.one * _data.punchScale, _data.punchDuration, _data.punchVibrato, _data.punchElasticity);
        }
        
        public void IncrementCount(int count, int value, SlotCountText text)
        {
            _incrementTween?.Kill(true);
            _incrementTween = TargetTo(count, value, _data.incrementDuration, _data.incrementEase, text);
        }
    }
}