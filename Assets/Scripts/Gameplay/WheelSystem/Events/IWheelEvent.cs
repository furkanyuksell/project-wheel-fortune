using Controllers.Enums;
using Core.EventBusSystem.Interfaces;

namespace Gameplay.WheelSystem.Events
{
    public interface IWheelEvent : IEvent
    {
        public struct OnWheelPreparation : IWheelEvent
        {
            public FortuneType FortuneType;
            public int FortuneLevel;
            
            public OnWheelPreparation(int fortuneLevel, FortuneType fortuneType)
            {
                FortuneLevel = fortuneLevel;
                FortuneType = fortuneType;
            }
        }
        
        public struct OnWheelReady : IWheelEvent { }
        
    }
}