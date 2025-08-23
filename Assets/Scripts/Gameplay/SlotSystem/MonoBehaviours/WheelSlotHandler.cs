using Gameplay.SlotSystem.Base;
using UnityEngine;

namespace Gameplay.SlotSystem.MonoBehaviours
{
    public class WheelSlotHandler : SlotHandler
    {
        public override void ReturnToPool()
        {
        }

        public override int GetPoolId()
        {
            return 1;
        }
    }
}