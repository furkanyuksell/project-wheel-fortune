using DISystem.Base;
using Managers.MonoBehaviours;
using UnityEngine;
using Utils.Abstract;

namespace DISystem.MonoBehaviours
{
    public class ProjectContext : BaseContext
    {
        [SerializeField] private GameManager _gameManager;

        protected override void Initialize()
        {
            RegisterInstance(InitializeContextDependent(_gameManager));
            base.Initialize();
        }
    }
}