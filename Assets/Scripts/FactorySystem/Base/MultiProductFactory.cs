using System.Collections.Generic;
using FactorySystem.Classes;
using UnityEngine;

namespace FactorySystem.Base
{
    public class MultiProductFactory<T> : BaseProductFactory<T> where T : BasePoolableProduct
    {
        [Header("Multi Product Configuration")]
        [SerializeField] private ProductInfo<T>[] _productInfos;

        protected override void InitializePools()
        {
            _productPools = new List<Queue<T>>();
            _activeProducts = new HashSet<T>();

            for (int i = 0; i < _productInfos.Length; i++)
            {
                var pool = new Queue<T>();
            
                for (int j = 0; j < _productInfos[i].poolSize; j++)
                {
                    var product = CreateProduct(i);
                    pool.Enqueue(product);
                }
            
                _productPools.Add(pool);
            }
        }

        protected override ProductInfo<T> GetProductInfo(int typeIndex) => _productInfos[typeIndex];
    }
}