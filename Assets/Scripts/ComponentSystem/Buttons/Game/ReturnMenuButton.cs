using ComponentSystem.Components;
using EventBusSystem.Utils;
using SceneManagementSystem.Enums;
using SceneManagementSystem.Interfaces;
using StateSystem.Enums;

namespace ComponentSystem.Buttons.Game
{
    public class ReturnMenuButton : ButtonComponent
    {
        protected override void OnClick()
        {
            EventDispatcher.Raise(new ISceneEvent.OnLoadSceneByType(SceneType.MainMenu));
        }
        
    }
}