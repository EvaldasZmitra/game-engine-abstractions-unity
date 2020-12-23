using GameMakingKit.Classes;
using GameMakingKit.Interfaces;
using UnityEngine;

namespace GameMakingKit._UnitySpecific
{
    class UnityGameObject: IGameObject
    {
        private readonly GameObject _gameObject;

        public UnityGameObject(GameObject reference)
        {
            _gameObject = reference;
            Reference = reference;
            Transform = new UnityTransform(reference.transform);
        }

        public ITransform Transform { get; set; }

        public bool ActiveSelf
        {
            get
            {
                return _gameObject.activeSelf;
            }
        }

        public object Reference { get; set; }

        public void SetActive(bool active)
        {
            _gameObject.SetActive(active);
        }
    }
}
