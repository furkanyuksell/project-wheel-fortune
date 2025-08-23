using Core.DISystem.Utils;
using Managers.MonoBehaviours;
using UnityEngine;
using UnityEngine.Serialization;

namespace Core.DISystem.MonoBehaviours
{
    public class ProjectContext : PersistentContext<ProjectContext>
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private SceneManager _sceneManager;
        [FormerlySerializedAs("_factoryManager")] [SerializeField] private ObjectPoolManager objectPoolManager;

        protected override void Initialize()
        {
            RegisterInstance(InitializeContextDependent(_gameManager));
            RegisterInstance(InitializeContextDependent(_sceneManager));
            RegisterInstance(InitializeContextDependent(objectPoolManager));
            base.Initialize();
        }
    }
}