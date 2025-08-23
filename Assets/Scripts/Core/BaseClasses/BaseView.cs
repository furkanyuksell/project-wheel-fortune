using UnityEngine;

namespace Core.BaseClasses
{
    public abstract class BaseView<TModel> : BaseBehaviour where TModel : ScriptableObject
    {
        protected TModel _model;

        public virtual void SetModel(TModel model)
        {
            _model = model;
            Refresh();
        }
        protected virtual void Refresh() { }
    }
}