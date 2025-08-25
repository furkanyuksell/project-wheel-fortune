using UnityEngine;

namespace Gameplay.ReviveSystem.Scriptables
{
    [CreateAssetMenu(fileName = "ReviveDataSO", menuName = "Data/Revive/ReviveDataSO", order = 0)]
    public class ReviveDataSO : ScriptableObject
    {
        public int reviveCost;
    }
}