using Core.ComponentSystem.Components;

namespace Gameplay.WheelSystem.Components
{
    public class SpinButton : ButtonComponent
    {

        public void ClickableStatus(bool status)
        {
            SetInteractable(status);
        }
        
    }
}