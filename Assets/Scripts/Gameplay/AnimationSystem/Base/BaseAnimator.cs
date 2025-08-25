using System;
using Core.ComponentSystem.Components;
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
        
        protected Tween MoveXAnchorAnimation(RectTransform target, float position, float duration, Ease ease = Ease.Linear)
        {
            return target.DOAnchorPosX(position, duration).SetLink(target.gameObject).SetEase(ease);
        }
        
        protected Tween PunchAnimation(Vector3 punch, float duration, int vibrato = 10, float elasticity = 1f, Ease ease = Ease.Linear)
        {
            return _transform.DOPunchScale(punch, duration, vibrato, elasticity).SetLink(_transform.gameObject).SetEase(ease);
        }

        protected Tween TargetTo(int count, int value, float duration, Ease ease = Ease.Linear, TextComponent text = null)
        {
            return DOTween.To(() => count, x =>
            {
                count = x;
                if(text) text.SetText(count.ToString());
            }, count + value, duration).SetLink(_transform.gameObject).SetEase(ease);
        }
    }
}