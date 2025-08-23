using UnityEngine;

namespace Core.BaseClasses
{
    public abstract class BaseBehaviour : MonoBehaviour
    {
        protected virtual void OnEnable()
        {
            Register(true);
        }
        
        protected virtual void OnDisable()
        {
            Register(false);
        }
        
        protected virtual void Register(bool isActive) { }
    }
}