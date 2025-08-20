using Core.ComponentSystem.Components;
using UnityEngine;

namespace Core.ComponentSystem.Buttons.Menu
{
    public class QuitButton : ButtonComponent
    {
        protected override void OnClick()
        {
            Debug.Log("QuitButton: OnClick - Quitting Application");
        }
    }
}