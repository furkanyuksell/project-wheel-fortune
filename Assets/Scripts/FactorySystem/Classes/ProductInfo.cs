using System;
using FactorySystem.Base;
using UnityEngine;

namespace FactorySystem.Classes
{
    [Serializable]
    public class ProductInfo<T> where T : BasePoolableProduct
    {
        [Range(1, 100)]
        public int poolSize = 10;
        public T prefab;   
    }
}