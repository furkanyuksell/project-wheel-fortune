using System;
using Core.BaseClasses;
using Core.DISystem.Interfaces;
using Core.EventBusSystem.Classes;
using Core.EventBusSystem.Utils;
using UnityEngine;

namespace Core.DISystem.Base
{
    public abstract class ContextDependentBehaviour : BaseBehaviour, IContextDependent
    {
        private IContext _context;
        private bool _isContextReady = false;
        public IContext Context => _context;

        protected override void OnDisable()
        {
            base.OnDisable();
            _context?.UnregisterDependent(this);
        }

        public void Initialize(IContext context)
        {
            _context?.UnregisterDependent(this);

            _context = context ?? throw new ArgumentNullException(nameof(context));
            _context.RegisterDependent(this);
        }
        
        public virtual void OnContextReady() 
        {
            if (_isContextReady)
                return;
            
            _isContextReady = true;
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