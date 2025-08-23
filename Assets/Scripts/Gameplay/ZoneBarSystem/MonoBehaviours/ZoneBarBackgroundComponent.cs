using System;
using Gameplay.ZoneBarSystem.Base;
using UnityEngine;

namespace Gameplay.ZoneBarSystem.MonoBehaviours
{
    public class ZoneBarBackgroundComponent : ZoneBarComponent
    {
        [Header("References")]
        [SerializeField] private ZoneBackgroundImage _zoneBackgroundImage;
        
        #region Pool Implementation
        public override void ReturnToPool()
        {
            _zoneBarPool.ReturnItem(this);
        }

        public override int GetPoolId()
        {
            return (int) ZoneBarComponentType.Background;
        }
        #endregion

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_zoneBackgroundImage) return;
            
            _zoneBackgroundImage = GetComponentInChildren<ZoneBackgroundImage>();
            if (!_zoneBackgroundImage) 
                Debug.LogError("ZoneBackgroundImage component is not assigned in ZoneBarBackgroundComponent. Please assign it in the inspector.", this);
        }
#endif
    }
}