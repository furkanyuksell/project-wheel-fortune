using System;

namespace DISystem.Interfaces
{
    public interface IContext
    {
        T Resolve<T>() where T : class;
        bool TryResolve<T>(out T instance) where T : class;
        bool IsInitialized { get; }

    }
}