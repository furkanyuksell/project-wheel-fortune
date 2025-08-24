using Controllers.MonoBehaviours;
using Core.DISystem.Base;
using UnityEngine;

namespace Core.DISystem.MonoBehaviours
{
    public class SceneContext : BaseContext
    {
        [SerializeField] private GameController gameController;
        [SerializeField] private WheelController _wheelController;
        [SerializeField] private PrizeBarController _prizeBarController;
        [SerializeField] private ZoneBarController _zoneBarController; 
        [SerializeField] private FortuneLevelController _fortuneLevelController;
        [SerializeField] private CurrencyController _currencyController;

        protected override void Initialize()
        {
            RegisterInstance(InitializeContextDependent(gameController));
            RegisterInstance(InitializeContextDependent(_wheelController));
            RegisterInstance(InitializeContextDependent(_prizeBarController));
            RegisterInstance(InitializeContextDependent(_zoneBarController));
            RegisterInstance(InitializeContextDependent(_fortuneLevelController));
            RegisterInstance(InitializeContextDependent(_currencyController));
            base.Initialize();
        }
    }
}