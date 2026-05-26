using UnityEngine;
using UnityEngine.Events;

namespace Jam.Game.Damageable
{
    public class Damageable : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 100;
        [SerializeField] private int health;
        public int Health { get => health; private set => health = value; }
        [SerializeField] private bool isDamageable = true;
        public bool IsDamageable { get => isDamageable; private set => isDamageable = value; }
        [SerializeField] private bool isHealable = true;
        public bool IsHealable { get => isHealable; private set => isHealable = value; }
        [SerializeField] private bool disableOnDeath = true;
        public bool IsDead { get { return Health <= 0; } }

        public UnityAction<int> onHeal;
        public UnityAction<int> onDamage;
        public UnityAction onDeath;

        void OnEnable()
        {
            Health = maxHealth;
        }

        void OnDisable()
        {
            Health = 0;
        }

        public void ModifyHealth(int amount)
        {
            if (amount < 0 && !IsDamageable) return;
            if (amount > 0 && !IsHealable) return;

            Health += amount;

            if (amount < 0) onDamage?.Invoke(-amount);
            else if (amount > 0) onHeal?.Invoke(amount);

            if (IsDead) Die();
        }

        public void Die()
        {
            onDeath?.Invoke();
            if (disableOnDeath) gameObject.SetActive(false);
        }

        public void SetDamageable(bool value)
        {
            IsDamageable = value;
        }

        public void SetHealable(bool value)
        {
            IsHealable = value;
        }
    }
}
