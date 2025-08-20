namespace Core.DISystem.Interfaces
{
    public interface IContextDependent
    {
        IContext Context { get; }
        void Initialize(IContext context);
        void OnContextReady();
    }
}