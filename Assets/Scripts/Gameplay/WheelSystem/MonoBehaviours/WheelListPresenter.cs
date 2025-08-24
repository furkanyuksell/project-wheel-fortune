using System;
using System.Collections.Generic;
using Core.BaseClasses;
using Core.DISystem.MonoBehaviours;
using Gameplay.SlotSystem.Base;
using Gameplay.SlotSystem.Enums;
using Gameplay.SlotSystem.MonoBehaviours;
using Gameplay.SlotSystem.Scriptables;
using Gameplay.WheelSystem.Components;
using Gameplay.WheelSystem.Scriptables;
using Managers.MonoBehaviours;
using UnityEngine;
using Utils;

namespace Gameplay.WheelSystem.MonoBehaviours
{
    public class WheelListPresenter : BaseListPresenter<WheelSlotView, BaseRewardSO>
    {
        #region Fields
        [Header("References")] 
        [SerializeField] private Transform _itemHolder;
        [SerializeField] private WheelImage _wheelImage;
        [SerializeField] private RectTransform _wheelRadius;
        #endregion
        
        #region Pool
        private SlotPool _slotPool;
        #endregion

        #region Privates

        private ViewType _viewType = ViewType.Wheel;

        #endregion
        
        public void Initialize()
        {
            _slotPool = ProjectContext.Instance.Resolve<ObjectPoolManager>().SlotPool;
        }

        public void Prepare(WheelDataSO wheelDataSO)
        {
            CreateViews(wheelDataSO);
            UpdateWheelImage(wheelDataSO);
        }

        private void CreateViews(WheelDataSO wheelDataSO)
        {
            float sliceAngle = 360f / wheelDataSO.wheelContainableSliceCount;
            
            for (int i = 0; i < wheelDataSO.wheelContainableSliceCount; i++)
            {
                Vector3 viewPos = Utilities.GetRadiusPos(sliceAngle, i) * GetWheelRadius();
                Vector3 viewRot = Utilities.GetRotationOnRadius(sliceAngle, i);
                
                var view = _slotPool.GetPooledItem((int)_viewType);
                view.Prepare(viewPos, viewRot, _itemHolder, wheelDataSO.GetRandomItem());
            }
        }

        private float GetWheelRadius() => _wheelRadius.rect.width / 2;
        private void UpdateWheelImage(WheelDataSO wheelDataSo)
        {
            if (_wheelImage != null)
                _wheelImage.SetSprite(wheelDataSo.wheelSprite);
            else
                Debug.LogWarning("WheelImage reference is not set in WheelListPresenter.");
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_wheelImage == null)
            {
                _wheelImage = GetComponentInChildren<WheelImage>();
                if (_wheelImage == null)
                {
                    Debug.LogError("WheelImage not found in WheelListPresenter. Please assign it in the inspector.");
                }
            }
        }
#endif
    }
}