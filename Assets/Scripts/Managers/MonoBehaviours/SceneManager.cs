using DISystem.Base;
using EventBusSystem.Classes;
using EventBusSystem.Utils;
using SceneManagementSystem.Enums;
using SceneManagementSystem.Interfaces;
using StateSystem.Enums;
using StateSystem.Events;
using UnityEngine;

namespace Managers.MonoBehaviours
{
    public class SceneManager : ContextDependentBehaviour
    {
        #region Events
        private EventBinding<ISceneEvent.OnLoadSceneByType> _onLoadSceneByTypeBinding;
        #endregion
        
        
        protected override void Register(bool isActive)
        {
            base.Register(isActive);
            if (isActive)
            {
                _onLoadSceneByTypeBinding = EventDispatcher.Subscribe<ISceneEvent.OnLoadSceneByType>(OnLoadSceneByTypeHandler);
            }
            else
            {
                EventDispatcher.Unsubscribe(_onLoadSceneByTypeBinding);
            }
        }

        private void OnLoadSceneByTypeHandler(ISceneEvent.OnLoadSceneByType args)
        {
            // Handle the scene loading logic based on the SceneType
            switch (args.SceneType)
            {
                case SceneType.Gameplay:
                    LoadScene((int)SceneType.Gameplay);
                    EventDispatcher.Raise(new IStateMachineEvent.OnChangeState<GameStateType>(GameStateType.LoadGameplay));
                    break;
                case SceneType.MainMenu:
                    LoadScene((int)SceneType.MainMenu);
                    EventDispatcher.Raise(new IStateMachineEvent.OnChangeState<GameStateType>(GameStateType.MainMenu));
                    break;
                default:
                    Debug.LogWarning($"SceneManager: Unhandled scene type {args.SceneType}");
                    break;
            }
        }

        private void LoadScene(int sceneId)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneId);
        }
    }
}