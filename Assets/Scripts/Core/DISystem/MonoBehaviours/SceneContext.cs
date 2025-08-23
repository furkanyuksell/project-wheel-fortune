using Controllers.MonoBehaviours;
using Core.DISystem.Base;
using UnityEngine;
using UnityEngine.Serialization;

namespace Core.DISystem.MonoBehaviours
{
    public class SceneContext : BaseContext
    {
        [SerializeField] private GameController gameController;
        [SerializeField] private WheelController _wheelController;
        [SerializeField] private PrizeBarController _prizeBarController;
        [SerializeField] private ZoneBarController _zoneBarController;

        protected override void Initialize()
        {
            RegisterInstance(InitializeContextDependent(gameController));
            RegisterInstance(InitializeContextDependent(_wheelController));
            RegisterInstance(InitializeContextDependent(_prizeBarController));
            RegisterInstance(InitializeContextDependent(_zoneBarController));
            base.Initialize();
        }
    }
}