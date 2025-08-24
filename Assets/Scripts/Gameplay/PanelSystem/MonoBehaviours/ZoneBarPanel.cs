using System.Collections.Generic;
using Controllers.Scriptables;
using Gameplay.PanelSystem.Base;
using Gameplay.ZoneBarSystem;
using Gameplay.ZoneBarSystem.Base;
using Gameplay.ZoneBarSystem.MonoBehaviours;
using Managers.MonoBehaviours;
using UnityEngine;

namespace Gameplay.PanelSystem.MonoBehaviours
{
    public class ZoneBarPanel : BasePanel
    {
        #region Contents
        [Header("References")]
        [SerializeField] private RectTransform _bgContent;
        [SerializeField] private RectTransform _textContent;
        #endregion

        #region Privates
        private FortuneDataSO _fortuneDataSO;
        #endregion

        #region DI
        private ZoneBarPool _zoneBarPool;
        #endregion

        #region Data
        private readonly Dictionary<int, (ZoneBarComponent, ZoneBarComponent)> _zoneLevelItems = new();
        #endregion
        public void Initialize(ZoneBarPool zoneBarPool, FortuneDataSO fortuneDataSO)
        {
            _zoneBarPool = zoneBarPool;
            _fortuneDataSO = fortuneDataSO;
            CreateComponents();
        }

        private void CreateComponents()
        {
            for (int i = 0; i < _fortuneDataSO.totalZoneCount; i++)
            {
                _zoneLevelItems.Add(i, (SpawnItem(ZoneBarComponentType.Background, i), SpawnItem(ZoneBarComponentType.Text, i)));
            }
        }

        private ZoneBarComponent SpawnItem(ZoneBarComponentType type, int i)
        {
            var item = _zoneBarPool.GetPooledItem((int)type);
            item.OnActivate(Vector3.zero, type == ZoneBarComponentType.Background ? _bgContent : _textContent);
            item.Prepare(i);
            return item;
        }
    }
}