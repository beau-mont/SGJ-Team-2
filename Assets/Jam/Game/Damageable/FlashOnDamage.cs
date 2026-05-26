using System.Collections;
using UnityEngine;

namespace Jam.Game.Damageable
{
    public class FlashOnDamage : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Gradient flashGradient;
        [SerializeField] private float flashDuration = 0.5f;
        [SerializeField] private Damageable damageable;
        private Color originalColor;
        private bool isFlashing = false;
        private Coroutine flashCoroutine;

        void Start()
        {
            if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();
            originalColor = spriteRenderer.color;

            if (damageable == null) damageable = GetComponent<Damageable>();
        }

        void OnEnable()
        {
            damageable.onDamage += Flash;
        }

        void OnDisable()
        {
            StopCoroutine(flashCoroutine);
            damageable.onDamage -= Flash;

            spriteRenderer.color = originalColor;
            isFlashing = false;
        }

        private void Flash(int damage)
        {
            if (isFlashing) StopCoroutine(flashCoroutine);
            flashCoroutine = StartCoroutine(FlashCoroutine());
        }

        private IEnumerator FlashCoroutine()
        {
            isFlashing = true;
            float elapsed = 0f;
            while (elapsed < flashDuration)
            {
                spriteRenderer.color = flashGradient.Evaluate(elapsed / flashDuration);
                elapsed += Time.deltaTime;
                yield return null;
            }
            spriteRenderer.color = originalColor;
            isFlashing = false;
            yield break;
        }
    }
}
