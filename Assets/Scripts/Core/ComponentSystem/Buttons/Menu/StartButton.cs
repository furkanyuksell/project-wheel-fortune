using Core.ComponentSystem.Components;
using Core.EventBusSystem.Utils;
using Core.SceneManagementSystem.Enums;
using Core.SceneManagementSystem.Interfaces;

namespace Core.ComponentSystem.Buttons.Menu
{
    public class StartButton : ButtonComponent
    {
        protected override void OnClick()
        {
            EventDispatcher.Raise(new ISceneEvent.OnLoadSceneByType(SceneType.Gameplay));
        }
    }
}