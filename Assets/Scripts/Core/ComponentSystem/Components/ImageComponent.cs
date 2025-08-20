using Core.ComponentSystem.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Core.ComponentSystem.Components
{
    public abstract class ImageComponent : CustomUIComponentBase
    {
        protected Image image;
        private float _height;
        private float _width;
        
        public RectTransform RectTransform => image.rectTransform;
        
        protected override void Setup()
        {
            image = GetComponent<Image>();
            _width = image.rectTransform.rect.width;
            _height = image.rectTransform.rect.height;
        }

        protected override void Configure()
        {
            
        }
        
        public void SetSprite(Sprite sprite)
        {
            image.sprite = sprite;
        }
    }
}