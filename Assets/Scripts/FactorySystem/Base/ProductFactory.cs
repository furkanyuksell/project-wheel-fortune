using System.Collections.Generic;
using FactorySystem.Classes;
using UnityEngine;

namespace FactorySystem.Base
{
    public class ProductFactory<T> : BaseProductFactory<T> where T : BasePoolableProduct
    {
        [Header("Single Product Configuration")] 
        [SerializeField] private ProductInfo<T> _productInfo;

        protected override void InitializePools()
        {
            _productPools = new List<Queue<T>> { new Queue<T>() };
            _activeProducts = new HashSet<T>();

            for (int i = 0; i < _productInfo.poolSize; i++)
            {
                var product = CreateProduct(0);
                _productPools[0].Enqueue(product);
            }
        }

        protected override ProductInfo<T> GetProductInfo(int typeIndex) => _productInfo;
        public T GetProduct() => GetProduct(0);
    }
}