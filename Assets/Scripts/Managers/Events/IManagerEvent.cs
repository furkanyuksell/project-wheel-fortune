using Core.EventBusSystem.Interfaces;

namespace Managers.Events
{
    public interface IManagerEvent : IEvent 
    {
        public struct OnAllItemsReturnedPool : IManagerEvent { }
    }
}