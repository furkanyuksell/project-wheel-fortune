using System;
using Core.ComponentSystem.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.ComponentSystem.Components
{
    public abstract class ButtonComponent : CustomUIComponentBase
    {
        [Header("References")]
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _txtContent;

        #region Privates
        private Action _onClickAction;
        #endregion
        
        protected override void Setup()
        {
            if (!_button) 
                _button = GetComponent<Button>();
            if (!_txtContent) 
                _txtContent = GetComponentInChildren<TextMeshProUGUI>();
        }

        protected override void Configure()
        {
            SetClickEvent();
        }

        private void SetClickEvent()
        {
            _button.onClick.AddListener(OnClick);
        }
        
        public void SetOnClickAction(Action onClick)
        {
            _onClickAction = onClick;
        }

        protected virtual void OnClick()
        {
            _onClickAction?.Invoke();
        }

        public void SetInteractable(bool value)
        {
            _button.interactable = value;
        }
        
        public virtual void SetText(string text)
        {
            _txtContent.text = text;
        }
    }
}