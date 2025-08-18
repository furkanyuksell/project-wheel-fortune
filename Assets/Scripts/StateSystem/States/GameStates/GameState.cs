using StateSystem.Base;
using StateSystem.Enums;
using UnityEngine;

namespace StateSystem.States.GameStates
{
    public class GameState : BaseState<GameStateType> 
    {
        public override GameStateType StateType { get; }

        protected GameState(GameStateType stateType)
        {
            StateType = stateType;
        }
        public override void Start()
        {
            Debug.Log(StateType + " Started");
        }

        public override void End()
        {
            Debug.Log(StateType + " Ended");
        }
        
    }
}