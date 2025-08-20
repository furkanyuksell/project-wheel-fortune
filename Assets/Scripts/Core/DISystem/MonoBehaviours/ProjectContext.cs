using Core.DISystem.Utils;
using Managers.MonoBehaviours;
using UnityEngine;

namespace Core.DISystem.MonoBehaviours
{
    public class ProjectContext : PersistentContext<ProjectContext>
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private SceneManager _sceneManager;

        protected override void Initialize()
        {
            RegisterInstance(InitializeContextDependent(_gameManager));
            RegisterInstance(InitializeContextDependent(_sceneManager));
            base.Initialize();
        }
    }
}