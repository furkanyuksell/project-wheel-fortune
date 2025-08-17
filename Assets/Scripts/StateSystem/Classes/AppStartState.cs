using StateSystem.Enums;
using StateSystem.States;

namespace StateSystem.Classes
{
    public class AppStartState : GameState
    {
        public AppStartState() : base(GameStateType.OnAppStart)
        {
        }

        public override void Start()
        {
            base.Start();
        }

        public override void End()
        { 
            base.End();
        }
    }
}