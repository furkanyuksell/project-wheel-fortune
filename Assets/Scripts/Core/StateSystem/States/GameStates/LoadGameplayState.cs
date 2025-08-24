using Core.EventBusSystem.Utils;
using Core.SceneManagementSystem.Interfaces;
using Core.StateSystem.Classes;
using Core.StateSystem.Enums;
using UnityEngine;

namespace Core.StateSystem.States.GameStates
{
    public class LoadGameplayState : GameState
    {
        public LoadGameplayState() : base(GameStateType.LoadGameplay)
        {
        }

        public override void Start(DataTransporter data = null)
        {
            base.Start(data);
            Debug.Log("GameScene Initialization Start");
            EventDispatcher.Raise(new ISceneEvent.OnGameSceneInitialization());
            ChangeState(GameStateType.Play);
        }

        public override void End()
        {
            base.End();
            
        }
    }
}