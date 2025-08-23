using Controllers.Base;
using Core.EventBusSystem.Classes;
using Core.EventBusSystem.Utils;
using Core.SceneManagementSystem.Interfaces;

namespace Controllers.MonoBehaviours
{
    public class GameSceneController : BaseController
    {
        #region Events
        private EventBinding<ISceneEvent.OnGameSceneInitialization> _onGameSceneInitializationBinding;
        #endregion

        #region Controllers
        private WheelController _wheelController;
        #endregion
        
        protected override void Register(bool isActive)
        {
            base.Register(isActive);
            if (isActive)
            {
                _onGameSceneInitializationBinding = EventDispatcher.Subscribe<ISceneEvent.OnGameSceneInitialization>(Initialize);
            }
            else
            {
                EventDispatcher.Unsubscribe(_onGameSceneInitializationBinding);
                _onGameSceneInitializationBinding = null;
            }
        }

        public override void Initialize()
        {
            _wheelController.InitializeStates();
        }

        protected override void ResolveDependencies()
        {
            _wheelController = ResolveDependency<WheelController>();
        }
    }
}