using System.Collections.Generic;
using Controllers.Scriptables;
using Core.EventBusSystem.Classes;
using Core.EventBusSystem.Utils;
using Gameplay.AnimationSystem.Classes;
using Gameplay.PanelSystem.Base;
using Gameplay.WheelSystem.Events;
using Gameplay.ZoneBarSystem;
using Gameplay.ZoneBarSystem.Base;
using Gameplay.ZoneBarSystem.MonoBehaviours;
using Gameplay.ZoneBarSystem.Scriptables;
using Managers.Events;
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
        [SerializeField] private ZoneBarDataSO _zoneBarDataSO;
        #endregion

        #region Privates
        private FortuneDataSO _fortuneDataSO;
        #endregion

        #region DI
        private ZoneBarPool _zoneBarPool;
        #endregion

        #region Animator
        private ZoneBarAnimator _zoneBarAnimator;
        #endregion
        
        #region Events
        private EventBinding<IManagerEvent.OnAllItemsReturnedPool> _onAllItemsReturnedPoolBinding;
        #endregion

        #region Data
        private readonly Dictionary<int, (ZoneBarComponent, ZoneBarComponent)> _zoneLevelItems = new();
        #endregion
        public void Initialize(ZoneBarPool zoneBarPool, FortuneDataSO fortuneDataSO)
        {
            _zoneBarPool = zoneBarPool;
            _fortuneDataSO = fortuneDataSO;
            _zoneBarAnimator = new ZoneBarAnimator(_bgContent, _textContent, transform);
            CreateComponents();
        }
        
        protected override void Register(bool isActive)
        {
            base.Register(isActive);
            if (isActive)
            {
                _onAllItemsReturnedPoolBinding = EventDispatcher
                    .Subscribe<IManagerEvent.OnAllItemsReturnedPool>(OnAllItemsReturnedPool);
            }
            else
            {
                EventDispatcher.Unsubscribe(_onAllItemsReturnedPoolBinding);
                _onAllItemsReturnedPoolBinding = null;
            }
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

        protected override void OnPanelPrepare(IWheelEvent.OnWheelPreparation eventData)
        {
            (_zoneLevelItems[eventData.FortuneLevel-1].Item1 as ZoneBarBackgroundComponent)!
                .UpdateBackground(_zoneBarDataSO.GetZoneBackground(eventData.FortuneType));
            _zoneBarAnimator.PlayBarAnimation();
        }
        
        private void OnAllItemsReturnedPool()
        {
            foreach (var items in _zoneLevelItems)
            {
                items.Value.Item1.ReturnToPool();
                items.Value.Item2.ReturnToPool();
            }   
        }
    }
}