using System.Collections.Generic;
using Controllers.Enums;
using Gameplay.WheelSystem.Scriptables;
using UnityEngine;

namespace Gameplay.WheelSystem.Classes
{
    public class WheelDataModel
    {
        private readonly Dictionary<FortuneType, WheelDataSO> _wheelDataSoDictionary = new();

        public WheelDataModel()
        {
            LoadWheelData();
        }

        private void LoadWheelData()
        {
            var wheelDataSos = Resources.LoadAll<WheelDataSO>("Scriptables/WheelData");
            foreach (var wheelDataSo in wheelDataSos)
                if (!_wheelDataSoDictionary.TryAdd(wheelDataSo.fortuneType, wheelDataSo)) 
                    Debug.LogWarning($"Duplicate WheelDataSO found for FortuneType: {wheelDataSo.fortuneType}");
        }
        
        public WheelDataSO GetWheelDataSO(FortuneType fortuneType)
        {
            if (_wheelDataSoDictionary.TryGetValue(fortuneType, out var wheelDataSo))
            {
                return wheelDataSo;
            }
            
            Debug.LogError($"WheelDataSO not found for FortuneType: {fortuneType}");
            return null;
        }
    }
}