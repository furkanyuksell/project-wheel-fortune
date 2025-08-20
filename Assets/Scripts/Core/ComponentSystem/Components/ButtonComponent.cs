using Core.ComponentSystem.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.ComponentSystem.Components
{
    public abstract class ButtonComponent : CustomUIComponentBase
    {
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _txtContent;

        protected override void Setup()
        {
            if (!_button) _button = GetComponent<Button>();
            if (!_txtContent) _txtContent = GetComponentInChildren<TextMeshProUGUI>();
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
            _txtContent.text = text;
        }

        public void SetTextFromSO(string text)
        {
        }
    }
}