using Core.ObjectPoolSystem.Base;
using Gameplay.IconSpawnSystem.MonoBehaviours;
using Gameplay.SlotSystem.MonoBehaviours;
using Gameplay.ZoneBarSystem.MonoBehaviours;
using Managers.Base;
using UnityEngine;

namespace Managers.MonoBehaviours
{
    public class ObjectPoolManager : BaseManager
    {
        [Header("References")]
        [SerializeField] private SlotPool _slotPool;
        [SerializeField] private ZoneBarPool _zoneBarPool;
        [SerializeField] private SpawnableIconPool _iconPool;


        #region Publics
        public SlotPool SlotPool => _slotPool;
        public ZoneBarPool ZoneBarPool => _zoneBarPool;
        public SpawnableIconPool IconPool => _iconPool;

        #endregion
    }
}