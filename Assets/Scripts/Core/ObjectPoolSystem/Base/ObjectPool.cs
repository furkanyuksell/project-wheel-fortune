using System.Collections.Generic;
using Core.ObjectPoolSystem.Classes;
using Core.ObjectPoolSystem.Interfaces;
using UnityEngine;

namespace Core.ObjectPoolSystem.Base
{
    public abstract class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour, IPoolable
    {
        [Header("References")] 
        [SerializeField] protected Transform _poolContainer;

        [Header("Configuration")] 
        [SerializeField] protected bool _allowPoolGrowth = true;
        [SerializeField] protected int _maxPoolSize = 100;

        [Header("Runtime Info")] 
        [SerializeField] protected int _totalCreated;
        [SerializeField] protected int _activeCount;

        protected List<Queue<T>> _itemPools;
        protected HashSet<T> _activeItems;

        protected virtual void Awake()
        {
            InitializePools();
        }

        protected abstract void InitializePools();

        protected virtual T CreateInstance(int poolId)
        {
            var poolItemInfo = GetPoolItemInfo(poolId);
            T pooledItem = Instantiate(poolItemInfo.prefab, _poolContainer);

            pooledItem.PoolParent = _poolContainer;
            pooledItem.OnReturnedToPool();

            _totalCreated++;
            return pooledItem;
        }

        public virtual T GetPooledItem(int typeIndex)
        {
            ValidateTypeIndex(typeIndex);

            var pool = _itemPools[typeIndex];
            T product;

            if (pool.Count > 0)
            {
                product = pool.Dequeue();
            }
            else if (_allowPoolGrowth && _totalCreated < _maxPoolSize)
            {
                product = CreateInstance(typeIndex);
            }
            else
            {
                Debug.LogWarning($"Pool exhausted for type {typeIndex}. Consider increasing pool size.");
                return null;
            }

            _activeItems.Add(product);
            _activeCount = _activeItems.Count;
            return product;
        }

        public virtual bool ReturnItem(T item)
        {
            if (item == null || !_activeItems.Contains(item))
            {
                return false;
            }

            int typeIndex = item.GetPoolId();
            ValidateTypeIndex(typeIndex);

            item.OnReturnedToPool();
            _itemPools[typeIndex].Enqueue(item);
            _activeItems.Remove(item);
            _activeCount = _activeItems.Count;

            return true;
        }

        protected virtual void ValidateTypeIndex(int index)
        {
            if (index < 0 || index >= _itemPools.Count)
            {
                throw new System.ArgumentOutOfRangeException($"Invalid product type index: {index}");
            }
        }

        protected abstract PoolItemInfo<T> GetPoolItemInfo(int typeIndex);

        protected virtual void OnDestroy()
        {
            _activeItems?.Clear();
            _itemPools?.Clear();
        }
    }
}