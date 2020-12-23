namespace GameMakingKit.Interfaces
{
    public interface ICamera
    {
        float FieldOfView { get; set; }
        void Update(float pitch, float yaw, float distance);
    }
}
