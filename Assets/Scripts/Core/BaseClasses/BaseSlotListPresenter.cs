using System.Collections.Generic;
using Gameplay.SlotSystem.Base;
using Gameplay.SlotSystem.Enums;

namespace Core.BaseClasses
{
    public abstract class BaseSlotListPresenter<TSlot> : BaseBehaviour
        where TSlot : BaseSlotHandler
    {
        protected readonly List<TSlot> _slots = new();
    }
}