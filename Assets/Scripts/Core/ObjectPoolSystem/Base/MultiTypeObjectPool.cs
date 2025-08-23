using System.Collections.Generic;
using Core.ObjectPoolSystem.Classes;
using Core.ObjectPoolSystem.Interfaces;
using UnityEngine;

namespace Core.ObjectPoolSystem.Base
{
    public class MultiTypeObjectPool<T> : ObjectPool<T> where T : MonoBehaviour, IPoolable
    {
        [Header("Multi Product Configuration")]
        [SerializeField] private PoolItemInfo<T>[] _itemInfos;

        protected override void InitializePools()
        {
            _itemPools = new List<Queue<T>>();
            _activeItems = new HashSet<T>();

            for (int i = 0; i < _itemInfos.Length; i++)
            {
                var pool = new Queue<T>();
            
                for (int j = 0; j < _itemInfos[i].poolSize; j++)
                {
                    var product = CreateInstance(i);
                    pool.Enqueue(product);
                }
            
                _itemPools.Add(pool);
            }
        }

        protected override PoolItemInfo<T> GetPoolItemInfo(int typeIndex) => _itemInfos[typeIndex];
    }
}