using System;
using Core.BaseClasses;
using Core.DISystem.MonoBehaviours;
using Core.ObjectPoolSystem.Base;
using DG.Tweening;
using Gameplay.IconSpawnSystem.Components;
using Gameplay.IconSpawnSystem.Scriptables;
using Managers.MonoBehaviours;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay.IconSpawnSystem.MonoBehaviours
{
    public class SpawnedIcon : PoolableObject
    {
        [Header("Changable Variables")]
        [SerializeField] private IconImage _iconImage;

        [Header("Privates")]
        [SerializeField] private IconSpawnSystemDataSO _systemData;
        private RectTransform _rectTransform;
        
        private SpawnableIconPool _iconPool;

        protected override void Awake()
        { 
            base.Awake();
            _rectTransform = GetComponent<RectTransform>();
        }

        private void Start()
        {
            _iconPool = ProjectContext.Instance.Resolve<ObjectPoolManager>().IconPool;
        }

        public void InitializeItem(Sprite sprite, Vector3 spawnUIPosition, Vector3 targetPos, Transform parent, float seperationDuration, float seperationRange, float movementDurationAfterSeperation)
        {
            transform.SetParent(parent);
            _iconImage.SetSprite(sprite);
            transform.position = Vector3.zero;
            gameObject.SetActive(true);
            _rectTransform.position = spawnUIPosition;
            _rectTransform.localScale = Vector3.one;
            _rectTransform.localRotation = Quaternion.Euler(Random.Range(0f, _systemData.initialRotationRandomizerValue) * Vector3.forward);

            _rectTransform.DOScale(_systemData.initialScalePower * Vector3.one, seperationDuration * _systemData.seperationPowerPercent)
                .SetLoops(2, LoopType.Yoyo)
                .SetLink(gameObject);

            _rectTransform.DOMove(new Vector2(spawnUIPosition.x, spawnUIPosition.y) + (Random.insideUnitCircle * seperationRange), seperationDuration)
                .SetEase(Ease.OutQuad)
                .SetLink(gameObject)
                .OnComplete(delegate
                {
                    Sequence dtTarget = DOTween.Sequence();

                    dtTarget
                        .Join(_rectTransform.DOLocalRotate(Vector3.zero, movementDurationAfterSeperation).SetEase(Ease.InBack))
                        .Join(_rectTransform.DOMove(targetPos, movementDurationAfterSeperation).SetEase(Ease.InBack));

                    dtTarget
                        .SetLink(gameObject)
                        .SetTarget(gameObject)
                        .OnComplete(TargetReachedCallback);
                });
        }

        private void TargetReachedCallback()
        {
            ReturnToPool();
            // _rectTransform.DOPunchScale(_systemData.targetReachedScalePower * Vector3.one,
            //         _systemData.targetReachedScaleDuration)
            //     .SetEase(Ease.Linear)
            //     .SetLink(gameObject)
            //     .SetTarget(gameObject)
            //     .OnComplete(ReturnToPool);
        }
        
        public override void ReturnToPool()
        {
            _iconPool.ReturnItem(this);
        }

        public override int GetPoolId()
        {
            return 0;
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (!_iconImage)
            {
                _iconImage = GetComponentInChildren<IconImage>();
                if (!_iconImage)
                {
                    Debug.LogError("Icon image not found.");
                }
            }
        }
#endif
    }
}