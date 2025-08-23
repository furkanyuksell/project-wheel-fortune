using Core.DISystem.Base;

namespace Controllers.Base
{
    public abstract class BaseController : ContextDependentBehaviour
    {
        public abstract void Initialize();
    }
}