using System;

namespace EventBusSystem.Interfaces
{
    public interface IEventBinding<T> {
        public Action<T> OnEvent { get; set; }
        public Action OnEventNoArgs { get; set; }
        public Func<T> OnEventFunc { get; set; }
    }
}