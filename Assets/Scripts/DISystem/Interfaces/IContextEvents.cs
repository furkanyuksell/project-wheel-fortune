using EventBusSystem.Interfaces;

namespace DISystem.Interfaces
{
    public interface IContextEvents
    {
        public struct OnContextInitialized : IEvent { }
        
    }
}