using ComponentSystem.Base;
using TMPro;
using UnityEngine.UI;

namespace ComponentSystem.Components
{
    public abstract class ButtonComponent : CustomUIComponentBase
    {
        private Button _button;
        private TextMeshProUGUI _textMesh;
        protected string text;

        protected override void Setup()
        {
            _button = GetComponentInChildren<Button>();
            _textMesh = GetComponentInChildren<TextMeshProUGUI>();
        }

        protected override void Configure()
        {
            SetClickEvent();
        }

        private void SetClickEvent()
        {
            _button.onClick.AddListener(OnClick);
        }

        protected virtual void OnClick()
        {
        }
        
        protected void SetInteractable(bool value)
        {
            _button.interactable = value;
        }
        
        protected virtual void SetText(string text)
        {
            _textMesh.text = text;
        }

        public void SetTextFromSO(string text)
        {
            this.text = text;
        }
    }
}