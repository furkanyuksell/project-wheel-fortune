using ComponentSystem.Components;
using UnityEngine;

namespace ComponentSystem.Buttons.Menu
{
    public class QuitButton : ButtonComponent
    {
        protected override void OnClick()
        {
            Debug.Log("QuitButton: OnClick - Quitting Application");
        }
    }
}