using Core.BaseClasses;
using UnityEngine;

namespace Gameplay.PanelSystem.Base
{
    public abstract class BasePanel : BaseBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform _content;
    }
}