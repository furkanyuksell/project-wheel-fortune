using Controllers.MonoBehaviours;
using Core.DISystem.Base;
using UnityEngine;

namespace Core.DISystem.MonoBehaviours
{
    public class SceneContext : BaseContext
    {
        [SerializeField] private WheelController _wheelController;

        protected override void Initialize()
        {
            RegisterInstance(InitializeContextDependent(_wheelController));
            base.Initialize();
        }
    }
}