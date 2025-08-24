using Core.DISystem.MonoBehaviours;
using Gameplay.SlotSystem.Base;
using Gameplay.SlotSystem.Enums;
using Managers.MonoBehaviours;

namespace Gameplay.SlotSystem.MonoBehaviours
{
    public class PrizeSlotHandler : BaseSlotHandler
    {
        public override void ReturnToPool()
        {
            ProjectContext.Instance.Resolve<ObjectPoolManager>().SlotPool.ReturnItem(this);
        }

        public override int GetPoolId()
        {
            return (int)SlotType.Prize;
        }
    }
}