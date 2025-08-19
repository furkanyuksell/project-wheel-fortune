using DISystem.MonoBehaviours;
using Managers.MonoBehaviours;
using UnityEngine;

namespace SystemInitializer
{
    public static class GameInitializer
    {
        private const string ProjectContextPrefabPath = "Prefabs/DI/ProjectContext";
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void InitializeBeforeScene()
        {
            CreateEssentialSystems();
        }
    
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        public static void InitializeAfterScene()
        {
        }
    
        private static void CreateEssentialSystems()
        {
            var projectContextPrefab = Resources.Load<ProjectContext>(ProjectContextPrefabPath);
            if (projectContextPrefab == null)
            {
                Debug.LogError("ProjectContext prefab not found! Ensure it exists in Resources/Prefabs/DI.");
                return;
            }
            var projectContext = Object.Instantiate(projectContextPrefab);
            Object.DontDestroyOnLoad(projectContext);
            
        }
    }
}