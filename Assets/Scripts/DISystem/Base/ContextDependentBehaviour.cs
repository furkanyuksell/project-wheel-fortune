using System;
using DISystem.Interfaces;
using UnityEngine;
using Utils.Abstract;

namespace DISystem.Base
{
    public abstract class ContextDependentBehaviour : BaseBehaviour, IContextDependent
    {
        private bool _isSubscribedToContextEvent = false;
        private IContext _context;
        public IContext Context => _context;

        protected override void OnDisable()
        {
            base.OnDisable();
            UnsubscribeFromContext();
        }

        public void Initialize(IContext context)
        {
            if (_context != null) 
                UnsubscribeFromContext();
            
            _context = context ?? throw new ArgumentNullException(nameof(context));
            SubscribeToContext();
        }
        
        private void SubscribeToContext()
        {
            if (_context != null && !_isSubscribedToContextEvent)
            {
                _context.OnContextInitialized += OnContextReady;
                _isSubscribedToContextEvent = true;
            
                if (_context is BaseContext baseContext && baseContext.IsInitialized)
                {
                    OnContextReady();
                }
            }
        }
        
        private void UnsubscribeFromContext()
        {
            if (_context == null || !_isSubscribedToContextEvent) return;
            
            _context.OnContextInitialized -= OnContextReady;
            _isSubscribedToContextEvent = false;
        }
        

        // Initialize with Action via BaseContent Awake after all contexts are constructed
        public virtual void OnContextReady() 
        {
            Debug.Log($"Constructed {GetType().Name}");
            ResolveDependencies();
        }

        protected virtual void ResolveDependencies() { }
        
        protected T ResolveDependency<T>() where T : class
        {
            if (_context == null)
            {
                Debug.LogError($"{GetType().Name}: Cannot resolve dependency {typeof(T).Name} - no context available");
                return null;
            }
        
            if (_context.TryResolve<T>(out var instance))
            {
                return instance;
            }
        
            Debug.LogError($"{GetType().Name}: Failed to resolve dependency {typeof(T).Name}");
            return null;
        }
    }
}