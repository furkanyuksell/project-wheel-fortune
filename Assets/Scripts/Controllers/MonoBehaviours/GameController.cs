using Controllers.Base;
using Controllers.Scriptables;
using Core.EventBusSystem.Classes;
using Core.EventBusSystem.Utils;
using Core.SceneManagementSystem.Interfaces;
using Core.StateSystem.Enums;
using UnityEngine;

namespace Controllers.MonoBehaviours
{
    public class GameController : BaseController
    {
        [Header("References")]
        [SerializeField] private FortuneDataSO _fortuneDataSO;
        
        #region Events
        private EventBinding<ISceneEvent.OnGameSceneInitialization> _onGameSceneInitializationBinding;
        #endregion

        #region Controllers
        private WheelController _wheelController;
        private ZoneBarController _zoneBarController;
        private PrizeBarController _prizeBarController;
        private LevelController _levelController;
        #endregion

        #region Publics
        public FortuneDataSO FortuneDataSO => _fortuneDataSO;
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
            _wheelController.Initialize();
            _zoneBarController.Initialize();
            _prizeBarController.Initialize();
            _levelController.Initialize();
            
            _wheelController.StartWheel();
        }

        protected override void ResolveDependencies()
        {
            _wheelController = ResolveDependency<WheelController>();
            _zoneBarController = ResolveDependency<ZoneBarController>();
            _prizeBarController = ResolveDependency<PrizeBarController>();
            _levelController = ResolveDependency<LevelController>();
        }
    }
}