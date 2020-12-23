using GameMakingKit.Interfaces;
using System.Numerics;

namespace GameMakingKit._UnitySpecific
{
    class UnityRigidbody : IRigidbody
    {
        public Vector3 Velocity { 
            get { 
                return UnityUtill.ToNumericsVector3(_rb.velocity); 
            } 
            set {
                _rb.velocity = UnityUtill.ToUnityVector3(value);
            } 
        }

        public ITransform Transform { get; }

        private readonly UnityEngine.Rigidbody _rb;

        public UnityRigidbody(UnityEngine.Rigidbody rigidbody)
        {
            _rb = rigidbody;
            Transform = new UnityTransform(_rb.transform);
        }

        public void MovePosition(Vector3 position)
        {
            _rb.MovePosition(UnityUtill.ToUnityVector3(position));
        }
    }
}
