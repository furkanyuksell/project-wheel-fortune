using DISystem.Base;
using Managers.MonoBehaviours;
using UnityEngine;

namespace DISystem.MonoBehaviours
{
    public class ProjectContext : BaseContext
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private SceneManager _sceneManager;
        private static ProjectContext _instance;
        public static ProjectContext Instance 
        { 
            get 
            {
                if (_instance == null)
                {
                    Debug.LogError("ProjectContext instance is null! Make sure it exists in the first scene.");
                }
                return _instance;
            } 
        }

        protected override void Awake()
        {
            if (!HandleSingleton()) 
                return;

            base.Awake();
        }

        private bool HandleSingleton()
        {
            if (_instance != null)
            {
                if (_instance == this)
                    return true;
                Destroy(gameObject);
                return false;
            }

            _instance = this;
        
            if (transform.parent != null) 
                transform.SetParent(null);
        
            DontDestroyOnLoad(gameObject);
            return true;
        }

        protected override void Initialize()
        {
            RegisterInstance(InitializeContextDependent(_gameManager));
            RegisterInstance(InitializeContextDependent(_sceneManager));
            base.Initialize();
        }
    }
}