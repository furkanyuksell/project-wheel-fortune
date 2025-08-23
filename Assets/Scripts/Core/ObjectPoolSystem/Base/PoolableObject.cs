using Core.BaseClasses;
using Core.DISystem.MonoBehaviours;
using Core.ObjectPoolSystem.Interfaces;
using Managers.MonoBehaviours;
using UnityEngine;

namespace Core.ObjectPoolSystem.Base
{
    public abstract class PoolableObject : BaseBehaviour, IPoolable
    {
        [Header("Transform Cache")]
        protected Transform _cachedTransform;

        #region Properties
        public Transform CachedTransform => _cachedTransform;
        public Transform PoolParent { get; set; }
        public bool IsActive { get; protected set; }
        #endregion

        protected virtual void Awake()
        {
            _cachedTransform = transform;
        }

        public abstract void ReturnToPool();

        protected virtual void ResetState()
        {
            IsActive = false;
        }

        public virtual void OnReturnedToPool()
        {
            ResetState();
            gameObject.SetActive(false);
            IsActive = false;
            _cachedTransform.SetParent(PoolParent, false);
        }

        public virtual void OnActivate(Vector3 position, Transform parent = null)
        {
            _cachedTransform.SetParent(parent ?? PoolParent);
            _cachedTransform.position = position;
            gameObject.SetActive(true);
            IsActive = true;
        }

        public abstract int GetPoolId();
    }
}