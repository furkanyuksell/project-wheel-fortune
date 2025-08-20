using UnityEngine;
using Utils;

namespace FactorySystem.Base
{
    public abstract class BasePoolableProduct : BaseBehaviour
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

        protected override void Register(bool isActive)
        {
            base.Register(isActive);
        }

        protected virtual void OnBeforeLevelQuit()
        {
            ReturnToPool();
        }

        public abstract void ReturnToPool();

        protected virtual void ResetBeforePooling()
        {
            IsActive = false;
        }

        public virtual void OnReturnToPool(bool isInitializing = false)
        {
            ResetBeforePooling();
            gameObject.SetActive(false);
            IsActive = false;
            _cachedTransform.SetParent(PoolParent, false);
        }

        public virtual void OnRetrieveFromPool(Vector3 position, Transform parent = null)
        {
            _cachedTransform.SetParent(parent ?? PoolParent);
            _cachedTransform.position = position;
            gameObject.SetActive(true);
            IsActive = true;
        }

        public abstract int GetProductTypeIndex();
    }
}