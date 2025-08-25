using Core.ComponentSystem.Components;
using Core.EventBusSystem.Utils;
using Core.SceneManagementSystem.Enums;
using Core.SceneManagementSystem.Interfaces;
using Managers.Events;

namespace Gameplay.ReviveSystem.Components
{
    public class GiveUpButton : ButtonComponent
    {
        protected override void OnClick()
        {
            EventDispatcher.Raise(new IManagerEvent.OnAllItemsReturnedPool());
            EventDispatcher.Raise(new ISceneEvent.OnLoadSceneByType(SceneType.MainMenu));
        }
    }
}