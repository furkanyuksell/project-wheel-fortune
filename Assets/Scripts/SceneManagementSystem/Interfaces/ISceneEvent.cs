using EventBusSystem.Interfaces;
using SceneManagementSystem.Enums;

namespace SceneManagementSystem.Interfaces
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