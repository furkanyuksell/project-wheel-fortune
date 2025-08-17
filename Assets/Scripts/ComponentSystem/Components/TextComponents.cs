using ComponentSystem.Base;
using TMPro;
using UnityEngine;

namespace ComponentSystem.Components
{
    public abstract class TextComponents : CustomUIComponentBase
    {
        private TextMeshProUGUI _textMesh;
        protected override void Setup()
        {
            _textMesh = GetComponentInChildren<TextMeshProUGUI>();
        }

        protected override void Configure()
        {
        }
        
        public void SetText(string text)
        {
            _textMesh.text = text;
        }

        public void SetColor(Color color)
        {
            _textMesh.color = color;
        }
    }
}