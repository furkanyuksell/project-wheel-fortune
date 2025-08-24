using Core.ComponentSystem.Components;
using Core.EventBusSystem.Utils;
using Core.SceneManagementSystem.Enums;
using Core.SceneManagementSystem.Interfaces;
using Managers.Events;

namespace Gameplay.PrizeBarSystem.Components
{
    public class ExitButton : ButtonComponent
    {
        protected override void OnClick()
        {
            base.OnClick();
            EventDispatcher.Raise(new IManagerEvent.OnAllItemsReturnedPool());
            EventDispatcher.Raise(new ISceneEvent.OnLoadSceneByType(SceneType.MainMenu));
        }
    }
}