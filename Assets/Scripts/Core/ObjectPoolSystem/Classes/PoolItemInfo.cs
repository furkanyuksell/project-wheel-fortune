using System;
using Core.ObjectPoolSystem.Interfaces;
using UnityEngine;

namespace Core.ObjectPoolSystem.Classes
{
    [Serializable]
    public class PoolItemInfo<T> where T : IPoolable
    {
        public int poolSize = 10;
        public T prefab;   
    }
}