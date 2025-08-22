using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Gameplay.ItemSystem.Base
{
    public abstract class BaseView<TModel> : BaseBehaviour
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