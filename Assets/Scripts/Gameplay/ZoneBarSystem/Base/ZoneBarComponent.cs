using System;
using Core.DISystem.MonoBehaviours;
using Core.ObjectPoolSystem.Base;
using Gameplay.ZoneBarSystem.MonoBehaviours;
using Managers.MonoBehaviours;
using UnityEngine;

namespace Gameplay.ZoneBarSystem.Base
{
    public abstract class ZoneBarComponent : PoolableObject
    {
        [SerializeField] private ZoneBarComponentType zoneBarComponentType;

        #region DI
        
        private ProjectContext _projectContext;
        protected ZoneBarPool _zoneBarPool;

        #endregion
        
        public virtual void Prepare(int i)
        {
            _zoneBarPool = ProjectContext.Instance.Resolve<ObjectPoolManager>().ZoneBarPool;
        }
    }
}