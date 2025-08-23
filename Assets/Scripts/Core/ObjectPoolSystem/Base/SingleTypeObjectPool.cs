using System.Collections.Generic;
using Core.ObjectPoolSystem.Classes;
using Core.ObjectPoolSystem.Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

namespace Core.ObjectPoolSystem.Base
{
    public class SingleTypeObjectPool<T> : ObjectPool<T> where T : MonoBehaviour, IPoolable
    {
        [FormerlySerializedAs("poolItemInfo")]
        [Header("Single Product Configuration")] 
        [SerializeField] private PoolItemInfo<T> _poolItemInfo;

        protected override void InitializePools()
        {
            _itemPools = new List<Queue<T>> { new Queue<T>() };
            _activeItems = new HashSet<T>();

            for (int i = 0; i < _poolItemInfo.poolSize; i++)
            {
                var product = CreateInstance(0);
                _itemPools[0].Enqueue(product);
            }
        }

        protected override PoolItemInfo<T> GetPoolItemInfo(int typeIndex) => _poolItemInfo;
        public T GetProduct() => GetPooledItem(0);
    }
}