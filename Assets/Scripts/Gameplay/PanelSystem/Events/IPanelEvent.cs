using Core.EventBusSystem.Interfaces;
using Gameplay.WheelSystem.Enums;

namespace Gameplay.PanelSystem.Events
{
    public interface IPanelEvent : IEvent 
    {
        public struct OnPanelPrepare : IPanelEvent
        {
            public FortuneType FortuneType { get; }
            public int FortuneLevel { get; }
            public OnPanelPrepare(int fortuneLevel, FortuneType fortuneType)
            {
                FortuneLevel = fortuneLevel;
                FortuneType = fortuneType;
            }
        }
        
    }
}