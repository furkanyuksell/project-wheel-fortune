using StateSystem.Enums;

namespace StateSystem.States.GameStates
{
    public class LoadGameplayState : GameState
    {
        public LoadGameplayState() : base(GameStateType.LoadGameplay)
        {
        }

        public override void Start()
        {
            base.Start();
            ChangeState(GameStateType.Play);
        }

        public override void End()
        {
            base.End();
            
        }
    }
}