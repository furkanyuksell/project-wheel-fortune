using StateSystem.Enums;

namespace StateSystem.States.GameStates
{
    public class AppStartState : GameState
    {
        public AppStartState() : base(GameStateType.AppStart)
        {
        }

        public override void Start()
        {
            base.Start();
            ChangeState(GameStateType.MainMenu);
        }

        public override void End()
        { 
            base.End();
        }
    }
}