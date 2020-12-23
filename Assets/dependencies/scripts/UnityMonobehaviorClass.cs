using UnityEngine;

namespace GameMakingKit._UnitySpecific
{
    public class UnityMonoBehaviourClass<T> : MonoBehaviour
    {
        public T ClassInstance { get; set; }
    }
}
