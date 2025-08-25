using System;
using System.Collections;
using Core.BaseClasses;
using Core.DISystem.MonoBehaviours;
using Core.EventBusSystem.Classes;
using Core.EventBusSystem.Utils;
using Gameplay.IconSpawnSystem.Events;
using Gameplay.IconSpawnSystem.MonoBehaviours;
using Gameplay.IconSpawnSystem.Scriptables;
using Managers.MonoBehaviours;
using UnityEngine;
using Utils;

namespace IconSpawnSystem
{
    public class IconSpawnHandler : BaseBehaviour
    {
        [Header("References")] 
        [SerializeField] private IconSpawnSystemDataSO _systemData;
        [SerializeField] private RectTransform _iconsHolder;
        [SerializeField] private RectTransform _defaultIconSpawnPoint;

        #region Privates
        private Vector2 _defaultIconSpawnPosition;
        private Action _onComplete;
        #endregion

        #region Events

        private EventBinding<ISpawnIconEvent.OnSpawnIcon> _iconSpawnBinding;

        #endregion
        
        #region Pool
        private SpawnableIconPool _spawnableIconPool;
        #endregion
        protected override void Register(bool isActive)
        {
            base.Register(isActive);
            if (isActive)
            {
                _iconSpawnBinding = EventDispatcher.Subscribe<ISpawnIconEvent.OnSpawnIcon>(OnRequestIconSpawn);
            }
            else
            {
                EventDispatcher.Unsubscribe(_iconSpawnBinding);
                _iconSpawnBinding = null;
            }
        }
        
        private void Start()
        {
            _spawnableIconPool = ProjectContext.Instance.Resolve<ObjectPoolManager>().IconPool;
            _defaultIconSpawnPosition = _defaultIconSpawnPoint.position;
        }

        private void OnRequestIconSpawn(ISpawnIconEvent.OnSpawnIcon eventData)
        {
            _onComplete = eventData.OnComplete;
            HandleIconSpawn(eventData.Sprite, eventData.SpawnUIPosition, eventData.TargetTransform);
        }

        private void HandleIconSpawn(Sprite sprite, Vector3 spawnUIPosition, Transform targetTransform)
        {
            if (_systemData == null)
            {
                Debug.LogError("_systemData is null!");
                return;
            }

            // count = Mathf.Min(_systemData.maxIconSpawnCount, count);
            var count = _systemData.maxIconSpawnCount;
            float seperationDuration =
                _systemData.animatedCurrencyUpdateDelay * _systemData.iconsSeperationDurationMultiplier;
            float targetSeperationRange =
                Mathf.Max(
                    Utilities.GetPercentageValue(count, 0, _systemData.maxIconSpawnCount * 1.5f) *
                    _systemData.iconsMaxSeperationRange,
                    _systemData.iconsMinSeperationRange);

            StartCoroutine(DelayedIconSpawn());

            IEnumerator DelayedIconSpawn()
            {
                for (int i = 0; i < count; i++)
                {
                    spawnUIPosition = spawnUIPosition == Vector3.zero ? _defaultIconSpawnPosition : spawnUIPosition;

                    if (!SpawnIcon(sprite, spawnUIPosition, targetTransform, seperationDuration,
                            targetSeperationRange, i == 0 ? _onComplete : null))
                    {
                        Debug.LogWarning($"Failed to spawn icon at index {i}");
                    }

                    yield return new WaitForEndOfFrame();
                }
            }
        }

        private bool SpawnIcon(Sprite sprite, Vector3 spawnUIPosition, Transform targetTransform, float seperationDuration,
            float targetSeperationRange, Action onComplete = null)
        {
            if (_iconsHolder == null)
            {
                Debug.LogWarning("Required transforms are null");
                return false;
            }

            var item = _spawnableIconPool.GetItem();
            if (item == null)
            {
                Debug.LogWarning($"Failed to get SpawnedIcon from Pool");
                return false;
            }

            item.InitializeItem(sprite,spawnUIPosition, targetTransform, _iconsHolder, seperationDuration,
                targetSeperationRange, _systemData.iconsMovementDuration, onComplete);
            return true;
        }
    }
}