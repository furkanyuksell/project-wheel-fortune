using System;
using Gameplay.CurrencySystem.Components;
using Gameplay.PanelSystem.Base;
using UnityEngine;

namespace Gameplay.CurrencySystem.MonoBehaviours
{
    public class CurrencyPanel : BasePanel
    {
        [SerializeField] private CurrencyText currencyText;

        public void SetCurrencyText(string text)
        {
            if (currencyText == null)
            {
                Debug.LogError("CurrencyText component is not assigned in CurrencyPanel.", this);
                return;
            }
            currencyText.SetText(text);
        }
#if UNITY_EDITOR
        private void OnValidate()
        {
            if (currencyText == null)
            {
                currencyText = GetComponentInChildren<CurrencyText>();
                if (currencyText == null)
                {
                    Debug.LogError("CurrencyText component not found in children of CurrencyPanel. Please assign it manually.", this);
                }
            }
            
        }
#endif
    }
}