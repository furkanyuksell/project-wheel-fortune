using System;
using DG.Tweening;
using Gameplay.AnimationSystem.Base;
using Gameplay.AnimationSystem.Scriptables;
using UnityEngine;

namespace Gameplay.AnimationSystem.Classes
{
    public class WheelAnimator : BaseAnimator<WheelAnimationDataSO>
    {
        public WheelAnimator(Transform transform) : base(transform)
        {   
            _data = Resources.Load<WheelAnimationDataSO>("Scriptables/Animation/WheelAnimationData");
        }

        public void PlaySpinAnimation(float target, Action onCompleteAction = null)
        {
            RotateAnimation(Vector3.forward * (target + (_data.wheelMinTurnCount * 360)),
                _data.spinDuration,
                _data.spinEase,
                RotateMode.FastBeyond360).OnComplete(() =>
            {
                onCompleteAction?.Invoke();
            });
        }
        
    }
}