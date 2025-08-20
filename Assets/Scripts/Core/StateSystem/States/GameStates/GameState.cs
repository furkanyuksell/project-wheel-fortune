using Core.StateSystem.Base;
using Core.StateSystem.Enums;
using UnityEngine;

namespace Core.StateSystem.States.GameStates
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
            Debug.Log(StateType + " GameState Started");
        }

        public override void End()
        {
            Debug.Log(StateType + " GameState Ended");
        }
        
    }
}