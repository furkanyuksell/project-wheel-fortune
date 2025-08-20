using System;
using Core.EventBusSystem.Classes;
using Core.EventBusSystem.Interfaces;

namespace Core.EventBusSystem.Utils
{
    public static class EventDispatcher
    {
        public static EventBinding<T> Subscribe<T>(Action<T> onEvent) where T : IEvent
        {
            var binding = new EventBinding<T>(onEvent);
            EventBus<T>.Add(binding);
            return binding;
        }
        
        public static EventBinding<T> Subscribe<T>(Action onEventNoArgs) where T : IEvent
        {
            var binding = new EventBinding<T>(onEventNoArgs);
            EventBus<T>.Add(binding);
            return binding;
        }
        
        public static EventBinding<T> Subscribe<T>(Func<T> onEventFunc) where T : IEvent
        {
            var binding = new EventBinding<T>(onEventFunc);
            EventBus<T>.Add(binding);
            return binding; 
        }
        
        public static void Unsubscribe<T>(EventBinding<T> binding) where T : IEvent
        {
            EventBus<T>.Remove(binding);
        }
        
        public static void Raise<T>(T eventAction) where T : IEvent
        {
            EventBus<T>.Raise(eventAction);
        }

        public static T Request<T>() where T : IEvent
        {
            return EventBus<T>.RaiseAndReturn();
        }
    }
}