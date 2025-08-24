using Core.BaseClasses;
using Core.EventBusSystem.Classes;
using Core.EventBusSystem.Utils;
using Gameplay.PanelSystem.Events;
using Gameplay.WheelSystem.Events;
using UnityEngine;

namespace Gameplay.PanelSystem.Base
{
    public abstract class BasePanel : BaseBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform _content;

        
        #region Events
        private EventBinding<IPanelEvent.OnPanelPrepare> _onPanelPrepareBinding;
        #endregion
        
        protected override void Register(bool isActive)
        {
            if (isActive)
            {
                _onPanelPrepareBinding = EventDispatcher.Subscribe<IPanelEvent.OnPanelPrepare>(OnPanelPrepare);
            }
            else
            {
                if (_onPanelPrepareBinding != null)
                {
                    EventDispatcher.Unsubscribe(_onPanelPrepareBinding);
                    _onPanelPrepareBinding = null;
                }
            }
        }

        protected virtual void OnPanelPrepare(IPanelEvent.OnPanelPrepare eventData) { }
    }
}