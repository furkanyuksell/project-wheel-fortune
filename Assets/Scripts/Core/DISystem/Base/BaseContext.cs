using System;
using System.Collections.Generic;
using Core.DISystem.Interfaces;
using Core.EventBusSystem.Utils;
using UnityEngine;
using Utils;

namespace Core.DISystem.Base
{
    public abstract class BaseContext : BaseBehaviour, IContext
    {
        private Dictionary<Type, object> _registeredInstances;
        private bool _isInitialized = false;

        #region IContext Implementation
        public bool IsInitialized => _isInitialized;
        #endregion
        protected virtual void Awake() { }

        private void Start()
        {
            _registeredInstances = new Dictionary<Type, object>();
            if (InitializeOnStart())
                Initialize();
        }

        protected virtual bool InitializeOnStart() => true;

        public void InitManual()
        {
            if (_isInitialized) return;
            Initialize();
        }

        protected virtual void Initialize()
        {
            _isInitialized = true;
            Debug.Log($"Context {GetType().Name} initialized.");
            EventDispatcher.Raise(new IContextEvents.OnContextInitialized());
        }
        
        protected T InitializeContextDependent<T>(T instance) where T : class, IContextDependent
        {
            if (instance == null)
                return null;
            instance.Initialize(this);
            return instance;
        }
        
        protected void RegisterInstance<T>(T instance) where T : class
        {
            if (instance == null)
                return;
            
            var type = typeof(T);
            if (_registeredInstances.ContainsKey(type))
            {
                Debug.LogWarning($"Type {type.Name} is already registered. Overwriting.");
            }
            _registeredInstances[type] = instance;
        }
        
        #region IContext Implementation

        public T Resolve<T>() where T : class
        {
            if (TryResolve<T>(out var instance))
            {
                return instance;
            }
            throw new InvalidOperationException($"No instance of type {typeof(T).Name} is registered in the context.");
        }

        public bool TryResolve<T>(out T instance) where T : class
        {
            if (_registeredInstances.TryGetValue(typeof(T), out var obj) && obj is T typedInstance)
            {
                instance = typedInstance;
                return true;
            }
        
            instance = null;
            return false;
        }
        
        #endregion
    }
}