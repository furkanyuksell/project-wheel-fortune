using Core.ComponentSystem.Components;
using Core.EventBusSystem.Utils;
using Core.StateSystem.Enums;
using Core.StateSystem.Events;

namespace Gameplay.WheelSystem.Components
{
    public class SpinButton : ButtonComponent
    {
        public void ClickableStatus(bool status)
        {
            SetInteractable(status);
        }

        protected override void OnClick()
        {
            base.OnClick();
            EventDispatcher.Raise(new IStateMachineEvent<WheelStateType>.OnChangeState(WheelStateType.Spinning));
        }
    }
}