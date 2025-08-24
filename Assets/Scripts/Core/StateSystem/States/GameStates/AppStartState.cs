using Core.StateSystem.Classes;
using Core.StateSystem.Enums;

namespace Core.StateSystem.States.GameStates
{
    public class AppStartState : GameState
    {
        public AppStartState() : base(GameStateType.AppStart)
        {
        }

        public override void Start(DataTransporter data = null)
        {
            base.Start(data);
            ChangeState(GameStateType.MainMenu);
        }

        public override void End()
        { 
            base.End();
        }
    }
}