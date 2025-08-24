using System.Collections.Generic;
using Core.DISystem.MonoBehaviours;
using Gameplay.SlotSystem.Base;
using Gameplay.SlotSystem.Enums;
using Gameplay.SlotSystem.MonoBehaviours;
using Managers.MonoBehaviours;

namespace Core.BaseClasses
{
    public abstract class BaseSlotListPresenter<TSlot> : BaseBehaviour
        where TSlot : BaseSlotHandler
    {
        protected readonly List<TSlot> _slots = new();
        
        protected SlotType _slotType;
        protected SlotPool _slotPool;
        public virtual void Initialize()
        {
            _slotPool = ProjectContext.Instance.Resolve<ObjectPoolManager>().SlotPool;
        }
    }
}