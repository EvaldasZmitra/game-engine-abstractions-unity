using GameMakingKit.Classes;
using GameMakingKit.Interfaces;
using System.Linq;

namespace GameMakingKit._UnitySpecific
{
    class UnityAnimator : IAnimator
    {
        private readonly UnityEngine.Animator _anim;

        public UnityAnimator(UnityEngine.Animator anim)
        {
            _anim = anim;
        }

        public void SetTrigger(string name)
        {
            _anim.SetTrigger(name);
        }

        public void SetBool(string name, bool value)
        {
            _anim.SetBool(name, value);
        }
    }
}
