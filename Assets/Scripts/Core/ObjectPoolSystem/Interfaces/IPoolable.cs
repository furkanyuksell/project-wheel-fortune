using UnityEngine;

namespace Core.ObjectPoolSystem.Interfaces
{
    public interface IPoolable
    {
        Transform PoolParent { get; set; }
        bool IsActive { get; }
        int GetPoolId();
        void OnReturnedToPool();
        void OnActivate(Vector3 position, Transform parent = null);
    }
}