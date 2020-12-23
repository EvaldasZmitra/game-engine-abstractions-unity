using System.Numerics;

namespace GameMakingKit._UnitySpecific
{
    public static class UnityUtill
    {
        public static Vector3 ToNumericsVector3(UnityEngine.Vector3 vector)
        {
            return new Vector3(vector.x, vector.y, vector.z);
        }

        public static UnityEngine.Vector3 ToUnityVector3(Vector3 vector)
        {
            return new UnityEngine.Vector3(vector.X, vector.Y, vector.Z);
        }

        public static Quaternion ToNumericsQuaternion(float pitch, float yaw, float roll)
        {
            return Quaternion.CreateFromYawPitchRoll(yaw, pitch, roll);
        }

        public static UnityEngine.Quaternion ToUnityQuaternion(float pitch, float yaw, float roll)
        {
            return UnityEngine.Quaternion.Euler(pitch, yaw, roll);
        }
    }
}
