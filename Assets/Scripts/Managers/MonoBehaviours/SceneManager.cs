using System.Collections;
using System.Threading.Tasks;
using Core.EventBusSystem.Classes;
using Core.EventBusSystem.Utils;
using Core.SceneManagementSystem.Enums;
using Core.SceneManagementSystem.Interfaces;
using Core.StateSystem.Enums;
using Core.StateSystem.Events;
using Managers.Base;
using UnityEngine;

namespace Managers.MonoBehaviours
{
    public class SceneManager : BaseManager
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
            switch (args.SceneType)
            {
                case SceneType.Gameplay:
                    LoadScene((int)SceneType.Gameplay, GameStateType.LoadGameplay);
                    break;
                case SceneType.MainMenu:
                    LoadScene((int)SceneType.MainMenu, GameStateType.MainMenu);
                    break;
                default:
                    Debug.LogWarning($"SceneManager: Unhandled scene type {args.SceneType}");
                    break;
            }
        }

        private void LoadScene(int sceneId, GameStateType gameStateType)
        {
            StartCoroutine(LoadSceneAsync(sceneId, gameStateType));
        }

        private IEnumerator LoadSceneAsync(int sceneId, GameStateType gameStateType)
        {
            AsyncOperation asyncOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneId);
    
            while (!asyncOperation.isDone)
                yield return null;
            
            EventDispatcher.Raise(new IStateMachineEvent.OnChangeState<GameStateType>(gameStateType));
        }
    }
}