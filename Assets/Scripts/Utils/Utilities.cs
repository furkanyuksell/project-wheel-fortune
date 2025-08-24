using UnityEngine;

namespace Utils
{
    public static class Utilities
    {
        public static Vector2 GetRadiusPos(float sliceAngle, int sliceIndex)
        {
            float angle = 90f - sliceAngle * sliceIndex;
            float x = Mathf.Cos(angle * Mathf.Deg2Rad);
            float y = Mathf.Sin(angle * Mathf.Deg2Rad);
            return new Vector2(x, y);
        }
        
        public static Vector3 GetRotationOnRadius(float sliceAngle, int sliceIndex)
        {
            float angle = -sliceAngle * sliceIndex;
            return Vector3.forward * angle;
        }
    }
}