using UnityEngine;

namespace DISystem.Base
{
    public abstract class BaseBehaviour : MonoBehaviour
    {
        protected virtual void Awake()
        {
            BindEvents();
        }
        
        protected virtual void OnEnable()
        {
            Register(true);
        }
        
        protected virtual void OnDisable()
        {
            Register(false);
        }
        
        protected virtual void BindEvents() { }
        protected virtual void Register(bool isActive) { }
    }
}