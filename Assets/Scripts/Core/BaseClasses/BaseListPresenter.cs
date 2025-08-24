using System.Collections.Generic;
using Gameplay.SlotSystem.Enums;
using UnityEngine;

namespace Core.BaseClasses
{
    public abstract class BaseListPresenter<TView, TModel> : BaseBehaviour
        where TView : BaseView<TModel> 
        where TModel : ScriptableObject
    {
        protected readonly List<TView> _views = new();
    }
}