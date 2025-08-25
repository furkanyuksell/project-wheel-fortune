using System;
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
            public Transform TargetTransform { get; }
            public Action OnComplete { get; set; }
            public OnSpawnIcon(Sprite sprite, Vector3 spawnUIPosition, Transform targetTransform, Action onComplete = null)
            {
                Sprite = sprite;
                SpawnUIPosition = spawnUIPosition;
                TargetTransform = targetTransform;
                OnComplete = onComplete;
            }
        }
        
    }
}