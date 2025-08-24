using Gameplay.AnimationSystem.Base;
using Gameplay.AnimationSystem.Scriptables;
using UnityEngine;

namespace Gameplay.AnimationSystem.Classes
{
    public class ZoneBarAnimator : BaseAnimator<ZoneBarAnimationDataSO>
    {
        private RectTransform _bgRectTransform;
        private RectTransform _txtRectTransform;
        public ZoneBarAnimator(RectTransform bgRectTransform, RectTransform txtRectTransform, Transform transform) : base(transform)
        {
            _data = Resources.Load<ZoneBarAnimationDataSO>("Scriptables/Animation/ZoneBarAnimationData");
            _bgRectTransform = bgRectTransform;
            _txtRectTransform = txtRectTransform;
        }

        public void PlayBarAnimation()
        {
            MoveBar(_bgRectTransform);
            MoveBar(_txtRectTransform);
        }

        private void MoveBar(RectTransform transform)
        {
            MoveXAnchorAnimation(transform,
                transform.anchoredPosition.x - _data.zoneBarInterval, 
                _data.duration, _data.ease);
        }
    }
}