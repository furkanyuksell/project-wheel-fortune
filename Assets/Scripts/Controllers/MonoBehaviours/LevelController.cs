using Controllers.Base;
using UnityEngine;

namespace Controllers.MonoBehaviours
{
    public class LevelController : BaseController
    {
        #region Privates
        private int _level;
        #endregion
        
        public override void Initialize()
        {
            _level = 1;
        }
        
        public int GetLevel()
        {
            return _level;
        }
        
        
    }
}