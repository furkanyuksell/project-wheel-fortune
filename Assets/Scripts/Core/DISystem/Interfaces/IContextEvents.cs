using Core.EventBusSystem.Interfaces;

namespace Core.DISystem.Interfaces
{
    public interface IContextEvents
    {
        public struct OnContextInitialized : IEvent { }
        
    }
}