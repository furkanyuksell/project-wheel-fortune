using Core.EventBusSystem.Interfaces;

namespace Controllers.Events
{
    public interface IControllerEvent : IEvent
    {
        public struct OnAddCurrency : IControllerEvent
        {
            public int Amount { get; }

            public OnAddCurrency(int amount)
            {
                Amount = amount;
            }
        }
        
    }
}