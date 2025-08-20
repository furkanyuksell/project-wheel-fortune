using Core.DISystem.Base;
using UnityEngine;

namespace Core.DISystem.Utils
{
    [DefaultExecutionOrder(-100)]
    public abstract class PersistentContext<T> : BaseContext where T : PersistentContext<T>
    {
        private static readonly object Lock = new();
        private static T _instance;

        public static T Instance
        {
            get
            {
                lock (Lock)
                {
                    if (_instance != null) return _instance;
                    
                    _instance = FindObjectOfType<T>();
                    if (_instance != null) return _instance;
                    
                    var go = new GameObject($"{typeof(T).Name} (Singleton)");
                    _instance = go.AddComponent<T>();
                    DontDestroyOnLoad(go);
                    return _instance;
                }
            }
        }
        
        protected override void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else if (_instance != this) 
                Destroy(gameObject);
        }
    }
}