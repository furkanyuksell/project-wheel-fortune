using UnityEngine;

namespace Controllers.Scriptables
{
    [CreateAssetMenu(fileName = "FortuneDataSO", menuName = "Data/General/FortuneDataSO", order = 1)]
    public class FortuneDataSO : ScriptableObject
    {
        public int safeZoneInterval;
        public int superZoneInterval;
        public int totalZoneCount;
    }
}