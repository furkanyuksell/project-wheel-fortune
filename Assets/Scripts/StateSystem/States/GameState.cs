using EventBusSystem.Utils;
using StateSystem.Base;
using StateSystem.Enums;
using StateSystem.Events;
using UnityEngine;

namespace StateSystem.States
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
            Debug.Log(nameof(GameState) + " Started");
        }

        public override void End()
        {
            Debug.Log(nameof(GameState) + " Ended");
        }
        
    }
}