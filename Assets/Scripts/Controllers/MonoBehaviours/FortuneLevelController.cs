using Controllers.Base;
using Gameplay.WheelSystem.Enums;
using UnityEngine;

namespace Controllers.MonoBehaviours
{
    public class FortuneLevelController : BaseController
    {
        #region Privates
        private FortuneType _currentFortuneType = FortuneType.None;
        private int _level;
        #endregion

        #region DI
        private GameController _gameController;
        #endregion

        protected override void ResolveDependencies()
        {
            _gameController = ResolveDependency<GameController>();
        }

        public override void Initialize()
        {
            _level = 1;
            _currentFortuneType = FortuneType.Bronze;
        }
        
        public int GetLevel()
        {
            return _level;
        }
        public void IncreaseLevel()
        {
            _level++;
            UpdateFortuneType();
        }

        public FortuneType GetFortuneType()
        {
            return _currentFortuneType;
        }

        private void UpdateFortuneType()
        {
            if (_level % _gameController.FortuneDataSO.superZoneInterval == 0)
                _currentFortuneType = FortuneType.Gold;
            else if (_level % _gameController.FortuneDataSO.safeZoneInterval == 0)
                _currentFortuneType = FortuneType.Silver;
            else
                _currentFortuneType = FortuneType.Bronze;
            
        }
    }
}