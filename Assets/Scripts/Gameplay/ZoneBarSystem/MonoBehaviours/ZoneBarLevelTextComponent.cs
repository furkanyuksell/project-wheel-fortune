using System;
using Core.DISystem.MonoBehaviours;
using Gameplay.ZoneBarSystem.Base;
using Managers.MonoBehaviours;
using UnityEngine;

namespace Gameplay.ZoneBarSystem.MonoBehaviours
{
    public class ZoneBarLevelTextComponent : ZoneBarComponent
    {
        [Header("References")]
        [SerializeField] private ZoneLevelText _zoneLevelText;
        
        public override void Prepare(int i)
        {
            base.Prepare(i);
            _zoneLevelText.SetText((i + 1).ToString());
        }

        #region Pool Implamentation
        public override void ReturnToPool()
        {
            _zoneBarPool.ReturnItem(this);
        }

        public override int GetPoolId()
        {
            return (int) ZoneBarComponentType.Text;
        }
        #endregion


#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_zoneLevelText) return;
            
            _zoneLevelText = GetComponentInChildren<ZoneLevelText>();
            if (!_zoneLevelText) 
                Debug.LogError("ZoneLevelText component is not assigned in ZoneBarLevelTextComponent. Please assign it in the inspector.", this);
        }
#endif
    }
}