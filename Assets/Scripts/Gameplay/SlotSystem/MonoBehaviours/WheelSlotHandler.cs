using Core.DISystem.MonoBehaviours;
using Gameplay.SlotSystem.Base;
using Gameplay.SlotSystem.Enums;
using Managers.MonoBehaviours;
using UnityEngine;

namespace Gameplay.SlotSystem.MonoBehaviours
{
    public class WheelSlotHandler : BaseSlotHandler
    {
        public override void ReturnToPool()
        {
            ProjectContext.Instance.Resolve<ObjectPoolManager>().SlotPool.ReturnItem(this);
        }

        public override int GetPoolId()
        {
            return (int)SlotType.Wheel;
        }
    }
}