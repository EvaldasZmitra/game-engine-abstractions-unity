using System.Numerics;

namespace GameMakingKit.Interfaces
{
    public interface ITransform
    {
        Vector3 Position { get; set; }
        Quaternion Rotation { get; set; }
        Vector3 Scale { get; set; }
        void LookAt(Vector3 position);
        Vector3 TransformVector(Vector3 vector);
        Vector3 Forward { get; set; }
    }
}
