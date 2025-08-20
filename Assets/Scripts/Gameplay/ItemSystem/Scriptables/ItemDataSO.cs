using Gameplay.ItemSystem.Enums;
using UnityEngine;

namespace Gameplay.ItemSystem.Scriptables
{
    [CreateAssetMenu(fileName = "ItemDataSO", menuName = "Data/Wheel Fortune/ItemDataSO", order = 0)]
    public class ItemDataSO : ScriptableObject
    {
        public Sprite sprite;
        public ItemType itemType;
        public RarityType rarityType;
        [Range(0, 100)]
        public float possibilityRatio;
    }
}
