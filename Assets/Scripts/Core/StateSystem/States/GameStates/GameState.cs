using Core.StateSystem.Base;
using Core.StateSystem.Enums;
using UnityEngine;

namespace Core.StateSystem.States.GameStates
{
    public class GameState : BaseState<GameStateType> 
    {
        public GameState(GameStateType stateType) : base(stateType)
        {
        }
    }
}