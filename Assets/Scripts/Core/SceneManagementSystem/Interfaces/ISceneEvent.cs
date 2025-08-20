using Core.EventBusSystem.Interfaces;
using Core.SceneManagementSystem.Enums;

namespace Core.SceneManagementSystem.Interfaces
{
    public interface ISceneEvent : IEvent
    {
        public struct OnLoadSceneByType : ISceneEvent
        {
            public SceneType SceneType;
            public OnLoadSceneByType(SceneType sceneType) => SceneType = sceneType;
        }

    }
}