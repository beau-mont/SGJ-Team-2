using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace Jam.Game.Damageable
{
    /// <summary>
    /// damages objects with a Damageable component on collision. Each object will only be damaged once until the object is disabled and re-enabled.
    /// </summary>
    public class DamageOnCollide : MonoBehaviour
    {
        [SerializeField] private int damageAmount = -10;
        private List<Damageable> damagedObjects;

        void OnEnable()
        {
            damagedObjects = new List<Damageable>();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.gameObject.TryGetComponent(out Damageable damageable)) return;
            if (damagedObjects.Contains(damageable)) return;

            damageable.ModifyHealth(damageAmount);
            damagedObjects.Add(damageable);
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.gameObject.TryGetComponent(out Damageable damageable)) return;
            if (damagedObjects.Contains(damageable)) return;

            damageable.ModifyHealth(damageAmount);
            damagedObjects.Add(damageable);
        }
    }
}
