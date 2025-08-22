namespace Core.DISystem.Interfaces
{
    public interface IContext
    {
        T Resolve<T>() where T : class;
        bool TryResolve<T>(out T instance) where T : class;
        bool IsInitialized { get; }
        void RegisterDependent(IContextDependent dependent);
        void UnregisterDependent(IContextDependent dependent);
    }
}