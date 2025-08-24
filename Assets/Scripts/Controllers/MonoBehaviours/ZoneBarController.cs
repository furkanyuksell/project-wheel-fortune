using System;
using Controllers.Base;
using Core.DISystem.MonoBehaviours;
using Core.EventBusSystem.Classes;
using Core.EventBusSystem.Utils;
using Gameplay.PanelSystem.MonoBehaviours;
using Gameplay.ZoneBarSystem.MonoBehaviours;
using Managers.Events;
using Managers.MonoBehaviours;
using UnityEngine;

namespace Controllers.MonoBehaviours
{
    public class ZoneBarController : BaseController
    {
        #region Panel
        [SerializeField] private ZoneBarPanel _zoneBarPanel;
        #endregion
        
        #region DI
        private ObjectPoolManager _objectPoolManager;
        private GameController _gameController;
        #endregion
        
        protected override void ResolveDependencies()
        {
            _gameController = ResolveDependency<GameController>();
        }
        public override void Initialize()
        {
            _objectPoolManager = ProjectContext.Instance.Resolve<ObjectPoolManager>();
            if (_objectPoolManager == null)
            {
                Debug.LogError("ObjectPoolManager is not assigned. Please ensure it is set before calling Initialize.");
                return;
            }

            _zoneBarPanel.Initialize(_objectPoolManager.ZoneBarPool, _gameController.FortuneDataSO); 
        }


#if UNITY_EDITOR
        private void OnValidate()
        {
            if (!_zoneBarPanel)
            {
                _zoneBarPanel = FindObjectOfType<ZoneBarPanel>();
                if (!_zoneBarPanel) Debug.LogError("ZoneBarPanel not found in the scene. Please assign it in the inspector or ensure it exists in the scene.");
            }
            
        }
#endif
    }
}