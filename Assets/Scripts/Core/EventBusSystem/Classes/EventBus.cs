using System.Collections.Generic;
using Core.EventBusSystem.Interfaces;

namespace Core.EventBusSystem.Classes
{
    public static class EventBus<T> where T : IEvent {
        static readonly HashSet<IEventBinding<T>> bindings = new HashSet<IEventBinding<T>>();
    
        public static void Add(EventBinding<T> binding) => bindings.Add(binding);
        public static void Remove(EventBinding<T> binding) => bindings.Remove(binding);

        public static void Raise(T @event) {
            foreach (var binding in bindings) {
                binding.OnEvent.Invoke(@event);
                binding.OnEventNoArgs.Invoke();
            }
        }
        public static T RaiseAndReturn()
        {
            foreach (var binding in bindings)
            {
                var result = binding.OnEventFunc.Invoke();
                if (result != null)
                    return result;
            }
            return default;
        }
        static void Clear() {
            bindings.Clear();
        }
    }
}