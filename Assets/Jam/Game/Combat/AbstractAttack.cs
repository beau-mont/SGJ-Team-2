using System.Collections.Generic;
using UnityEngine;

namespace Jam.Game.Combat
{
    public abstract class AbstractAttack : ScriptableObject
    {
        public abstract int Priority { get; }
        public abstract List<AbstractAttack> ComboRequirement { get; }
        public abstract string AnimationTrigger { get; }

        public abstract void Activate(GameObject user, Animator animator);
        public abstract void Activate(GameObject user, List<Animator> animators);
    }
}
