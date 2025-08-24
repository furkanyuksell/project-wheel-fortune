using Core.EventBusSystem.Interfaces;
using Gameplay.WheelSystem.Enums;

namespace Gameplay.PanelSystem.Events
{
    public interface IPanelEvent : IEvent 
    {
        public struct OnPanelPrepare : IPanelEvent
        {
            public FortuneType FortuneType { get; }
            public OnPanelPrepare(FortuneType fortuneType)
            {
                FortuneType = fortuneType;
            }
        }
        
    }
}