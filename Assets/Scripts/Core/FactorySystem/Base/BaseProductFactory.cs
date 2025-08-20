using System.Collections.Generic;
using Core.FactorySystem.Classes;
using UnityEngine;

namespace Core.FactorySystem.Base
{
    public abstract class BaseProductFactory<T> : MonoBehaviour where T : BasePoolableProduct
    {
        [Header("References")] 
        [SerializeField] protected Transform _poolContainer;

        [Header("Configuration")] 
        [SerializeField] protected bool _allowPoolGrowth = true;
        [SerializeField] protected int _maxPoolSize = 100;

        [Header("Runtime Info")] 
        [SerializeField] protected int _totalCreated;
        [SerializeField] protected int _activeCount;

        protected List<Queue<T>> _productPools;
        protected HashSet<T> _activeProducts;

        protected virtual void Awake()
        {
            InitializePools();
        }

        protected abstract void InitializePools();

        protected virtual T CreateProduct(int typeIndex)
        {
            var productInfo = GetProductInfo(typeIndex);
            T product = Instantiate(productInfo.prefab, _poolContainer);

            product.PoolParent = _poolContainer;
            product.OnReturnToPool(true);

            _totalCreated++;
            return product;
        }

        public virtual T GetProduct(int typeIndex = 0)
        {
            ValidateTypeIndex(typeIndex);

            var pool = _productPools[typeIndex];
            T product;

            if (pool.Count > 0)
            {
                product = pool.Dequeue();
            }
            else if (_allowPoolGrowth && _totalCreated < _maxPoolSize)
            {
                product = CreateProduct(typeIndex);
            }
            else
            {
                Debug.LogWarning($"Pool exhausted for type {typeIndex}. Consider increasing pool size.");
                return null;
            }

            _activeProducts.Add(product);
            _activeCount = _activeProducts.Count;
            return product;
        }

        public virtual bool ReturnToPool(T product)
        {
            if (product == null || !_activeProducts.Contains(product))
            {
                return false;
            }

            int typeIndex = product.GetProductTypeIndex();
            ValidateTypeIndex(typeIndex);

            product.OnReturnToPool();
            _productPools[typeIndex].Enqueue(product);
            _activeProducts.Remove(product);
            _activeCount = _activeProducts.Count;

            return true;
        }

        protected virtual void ValidateTypeIndex(int index)
        {
            if (index < 0 || index >= _productPools.Count)
            {
                throw new System.ArgumentOutOfRangeException($"Invalid product type index: {index}");
            }
        }

        protected abstract ProductInfo<T> GetProductInfo(int typeIndex);

        public virtual int GetProductTypeCount() => _productPools.Count;

        public virtual int GetAvailableCount(int typeIndex = 0)
        {
            ValidateTypeIndex(typeIndex);
            return _productPools[typeIndex].Count;
        }

        public virtual int GetActiveCount() => _activeCount;

        protected virtual void OnDestroy()
        {
            _activeProducts?.Clear();
            _productPools?.Clear();
        }
    }
}