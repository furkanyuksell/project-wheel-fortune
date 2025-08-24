using System.Collections.Generic;
using Core.DISystem.MonoBehaviours;
using Core.EventBusSystem.Classes;
using Core.EventBusSystem.Utils;
using Gameplay.SlotSystem.Base;
using Gameplay.SlotSystem.Enums;
using Gameplay.SlotSystem.MonoBehaviours;
using Managers.Events;
using Managers.MonoBehaviours;

namespace Core.BaseClasses
{
    public abstract class BaseSlotListPresenter<TSlot> : BaseBehaviour
        where TSlot : BaseSlotHandler
    {
        #region Protected
        protected readonly List<TSlot> _slots = new();
        protected SlotType _slotType;
        protected SlotPool _slotPool;
        #endregion

        #region Events

        private EventBinding<IManagerEvent.OnAllItemsReturnedPool> _onAllItemsReturnedPoolBinding;

        #endregion
        
        
        public virtual void Initialize()
        {
            _slotPool = ProjectContext.Instance.Resolve<ObjectPoolManager>().SlotPool;
        }

        protected override void Register(bool isActive)
        {
            base.Register(isActive);
            if (isActive)
            {
                _onAllItemsReturnedPoolBinding = EventDispatcher
                    .Subscribe<IManagerEvent.OnAllItemsReturnedPool>(OnAllItemsReturnedPool);
            }
            else
            {
                EventDispatcher.Unsubscribe(_onAllItemsReturnedPoolBinding);
                _onAllItemsReturnedPoolBinding = null;
            }
        }

        private void OnAllItemsReturnedPool()
        {
            foreach (var slot in _slots) 
                slot.ReturnToPool();
            _slots.Clear();
        }
    }
}