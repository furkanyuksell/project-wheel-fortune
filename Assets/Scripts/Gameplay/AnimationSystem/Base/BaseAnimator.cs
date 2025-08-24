using DG.Tweening;
using Gameplay.AnimationSystem.Scriptables;
using UnityEngine;

namespace Gameplay.AnimationSystem.Base
{
    public abstract class BaseAnimator<TData> where TData : BaseAnimationDataSO 
    {
        protected Transform _transform;
        protected TData _data;
        protected BaseAnimator(Transform transform)
        {
            _transform = transform;
        }
        
        protected Tween RotateAnimation(Vector3 rotation, float duration, Ease ease = Ease.Linear, RotateMode rotateMode = RotateMode.Fast)
        {
            return _transform.DOLocalRotate(rotation, duration, rotateMode).SetLink(_transform.gameObject).SetEase(ease);
        }
    }
}