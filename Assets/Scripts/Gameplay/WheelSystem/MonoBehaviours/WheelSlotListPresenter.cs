using Core.BaseClasses;
using Core.DISystem.MonoBehaviours;
using Gameplay.SlotSystem.Base;
using Gameplay.SlotSystem.Classes;
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
    public class WheelSlotListPresenter : BaseSlotListPresenter<WheelSlotHandler>
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
        private SlotType _slotType = SlotType.Wheel;
        private float _sliceAngle;
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
            _sliceAngle = 360f / wheelDataSO.wheelContainableSliceCount;
            
            for (int i = 0; i < wheelDataSO.wheelContainableSliceCount; i++)
            {
                PrepareView(wheelDataSO, _sliceAngle, i);
            }
        }

        private void PrepareView(WheelDataSO wheelDataSO, float sliceAngle, int i)
        {
            Vector3 slotPos = Utilities.GetRadiusPos(sliceAngle, i) * GetWheelRadius();
            Vector3 slotRot = Utilities.GetRotationOnRadius(sliceAngle, i);

            BaseRewardSO reward = wheelDataSO.GetRandomItem();
                
            BaseSlotHandler slotHandler = _slotPool.GetPooledItem((int)_slotType);
            slotHandler.Prepare(slotPos, slotRot, _itemHolder, reward);
            _slots.Add(slotHandler as WheelSlotHandler);
        }

        private float GetWheelRadius() => _wheelRadius.rect.width / 2;
        private void UpdateWheelImage(WheelDataSO wheelDataSo)
        {
            if (_wheelImage != null)
                _wheelImage.SetSprite(wheelDataSo.wheelSprite);
            else
                Debug.LogWarning("WheelImage reference is not set in WheelListPresenter.");
        }
        public (RewardSlotData, float) GetSpinResult()
        {
            float dropRate = 0;
            foreach (var wheelSlotHandler in _slots)
            {
                dropRate += wheelSlotHandler.rewardDataSO.dropRate;
            }
            
            float randomValue = Random.Range(0, dropRate);
            
            float currentRatio = 0;

            foreach (var wheelSlotHandler in _slots)
            {
                currentRatio += wheelSlotHandler.rewardDataSO.dropRate;
                if (randomValue <= currentRatio)
                {
                    return (wheelSlotHandler.slotData, _sliceAngle * _slots.IndexOf(wheelSlotHandler));
                }
            }
            return (null, 0);   
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