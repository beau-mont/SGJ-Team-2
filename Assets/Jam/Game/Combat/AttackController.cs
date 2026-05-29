using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Jam.Game.Combat
{
    public class AttackController : MonoBehaviour
    {
        [SerializeField] private GameObject user;
        [SerializeField] private List<Animator> animators;

        public List<AbstractAttack> attacks1;
        public List<AbstractAttack> attacks2;
        public List<AbstractAttack> specials;

        [SerializeField] private List<AbstractAttack> lastAttacks;
        public float forgetTime = 1f;
        public float lastAttackTime;
        public float hardDelay = 0.25f; // delay before another attack input is accepted

        public void Attack1()
        {
            TryInput(attacks1);
        }

        public void Attack2()
        {
            TryInput(attacks2);
        }

        public void Special()
        {
            TryInput(specials);
        }

        private void TryInput(List<AbstractAttack> attackList)
        {
            //if (!(animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") || animator.GetCurrentAnimatorStateInfo(0).IsName("Running"))) return;

            List<AbstractAttack> attacks = attackList.OrderByDescending(a => a.Priority).ToList();
            if (attacks.Count() == 0) return;
            if (Time.time < lastAttackTime + hardDelay)
            {
                Debug.Log($"cooldown");
                return;
            }

            Debug.Log($"Frame #{Time.frameCount}");

            if (Time.time > lastAttackTime + forgetTime) lastAttacks.Clear();

            foreach (var attack in attacks)
            {
                Debug.Log($"checking if attack {attack.name} meets requirements");

                if (IsCombo(lastAttacks, attack.ComboRequirement))
                {
                    ActivateAttack(attack);
                    break;
                }
            }
        }

        private void ActivateAttack(AbstractAttack attack)
        {
            attack.Activate(user, animators);
            Debug.Log($"used attack {attack.name}");
            lastAttacks.Insert(0, attack);
            lastAttackTime = Time.time;
        }

        private bool IsCombo(List<AbstractAttack> main, List<AbstractAttack> query)
        {
            if (main == null || query == null) return false;
            if (query.Count > main.Count) return false; 

            if (query.Count == 0) return true;

            for (int i = 0; i < main.Count; i++)
            {
                Debug.Log($"i={i}. main i:{main[i].name}, query i: {query[i].name}");
                if (main[i] == query[i] && i == query.Count - 1) return true;
                if (main[i] != query[i]) return false;
            }

            return false;
        }
    }
}