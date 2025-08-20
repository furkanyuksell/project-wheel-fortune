using Core.ComponentSystem.Components;
using Core.EventBusSystem.Utils;
using Core.SceneManagementSystem.Enums;
using Core.SceneManagementSystem.Interfaces;

namespace Core.ComponentSystem.Buttons.Game
{
    public class ReturnMenuButton : ButtonComponent
    {
        protected override void OnClick()
        {
            EventDispatcher.Raise(new ISceneEvent.OnLoadSceneByType(SceneType.MainMenu));
        }
        
    }
}