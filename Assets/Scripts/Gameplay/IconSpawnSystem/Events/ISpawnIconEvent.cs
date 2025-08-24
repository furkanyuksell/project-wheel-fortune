using Core.EventBusSystem.Interfaces;
using UnityEngine;

namespace Gameplay.IconSpawnSystem.Events
{
    public interface ISpawnIconEvent : IEvent
    {
        public struct OnSpawnIcon : ISpawnIconEvent
        {
            public Sprite Sprite { get; }
            public Vector3 SpawnUIPosition { get; }
            public Vector3 TargetUIPosition { get; }
            public OnSpawnIcon(Sprite sprite, Vector3 spawnUIPosition, Vector3 targetUIPosition)
            {
                Sprite = sprite;
                SpawnUIPosition = spawnUIPosition;
                TargetUIPosition = targetUIPosition;
            }
        }
        
    }
}