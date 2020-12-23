using GameMakingKit.Interfaces;
using System.Numerics;

namespace GameMakingKit._UnitySpecific
{
    public class UnityTransform: ITransform
    {
        private readonly UnityEngine.Transform _transform;

        public UnityTransform(UnityEngine.Transform transform)
        {
            _transform = transform;
        }

        public Vector3 Position
        {
            get
            {
                return UnityUtill.ToNumericsVector3(_transform.position);
            }
            set
            {
                _transform.position = UnityUtill.ToUnityVector3(value);
            }
        }

        public Quaternion Rotation
        {
            get
            {
                return UnityUtill.ToNumericsQuaternion(_transform.rotation.x, _transform.rotation.y, _transform.rotation.z);
            }
            set
            {
                _transform.rotation = UnityUtill.ToUnityQuaternion(value.X, value.Y, value.Z);
            }
        }

        public Vector3 Scale {
            get
            {
                return UnityUtill.ToNumericsVector3(_transform.localScale);
            }
            set
            {
                _transform.localScale = UnityUtill.ToUnityVector3(value);
            }
        }

        public Vector3 Forward {
            get 
            {
                return UnityUtill.ToNumericsVector3(_transform.forward);
            }
            set
            {
                _transform.forward = UnityUtill.ToUnityVector3(value);
            }
        }

        public void LookAt(Vector3 position)
        {
            _transform.LookAt(UnityUtill.ToUnityVector3(position));
        }

        public Vector3 TransformVector(Vector3 vector)
        {
            var transformedVector = _transform.TransformVector(UnityUtill.ToUnityVector3(vector));
            return UnityUtill.ToNumericsVector3(transformedVector);
        }
    }
}