using ComponentSystem.Components;
using EventBusSystem.Utils;
using SceneManagementSystem.Enums;
using SceneManagementSystem.Interfaces;

namespace ComponentSystem.Buttons.Menu
{
    public class StartButton : ButtonComponent
    {
        protected override void OnClick()
        {
            EventDispatcher.Raise(new ISceneEvent.OnLoadSceneByType(SceneType.Gameplay));
        }
    }
}