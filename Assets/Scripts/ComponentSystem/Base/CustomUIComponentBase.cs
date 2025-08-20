using UnityEngine;
using Utils;

namespace ComponentSystem.Base
{
    public abstract class CustomUIComponentBase : BaseBehaviour
    {
        protected virtual void Awake() => Init();

        protected abstract void Setup();
        protected abstract void Configure();

        private void Init()
        {
            Setup();    
            Configure();
        }
        
#if UNITY_EDITOR
        private void OnValidate()
        {
            Setup();
        }
#endif
    }
}