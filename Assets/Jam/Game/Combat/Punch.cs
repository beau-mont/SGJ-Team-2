using UnityEngine;
using System.Collections.Generic;

namespace Jam.Game.Combat
{
    [CreateAssetMenu(fileName = "Punch", menuName = "Attacks/Punch")]
    public class Punch : AbstractAttack
    {
        [SerializeField] private int priority;
        public override int Priority => priority;
        [SerializeField] private List<AbstractAttack> comboRequirement;
        public override List<AbstractAttack> ComboRequirement => comboRequirement; 
        [SerializeField] private string animationTrigger;
        public override string AnimationTrigger => animationTrigger;

        public override void Activate(GameObject user, Animator animator)
        {
            animator.SetTrigger(AnimationTrigger);
        }

        public override void Activate(GameObject user, List<Animator> animators)
        {
            foreach (var animator in animators)
            {
                animator.SetTrigger(AnimationTrigger);
            }
        }
    }
}