using UnityEngine;
using UnityEngine.InputSystem;

namespace Jam.Game.Player
{
    public class PlayerController : MonoBehaviour
    {
        InputAction moveAction;
        [SerializeField] private float horizontalSpeed = 5f;
        [SerializeField] private float verticalSpeed = 2.5f;

        [SerializeField] private float minX;
        [SerializeField] private float maxX;
        [SerializeField] private float minY;
        [SerializeField] private float maxY;

        [SerializeField] private AnimationCurve sizeCurve;

        public GameObject playerLegs;
        public GameObject playerTorso;
        public GameObject playerArms;
        public GameObject playerHead;
        private Animator legsAnimator;
        private Animator torsoAnimator;
        private Animator armsAnimator;
        private Animator headAnimator;

        void Awake()
        {
            moveAction = InputSystem.actions.FindAction("Move");
            legsAnimator = playerLegs.GetComponent<Animator>();
            torsoAnimator = playerTorso.GetComponent<Animator>();
            armsAnimator = playerArms.GetComponent<Animator>();
            headAnimator = playerHead.GetComponent<Animator>();
        }

        void FixedUpdate()
        {
            if (moveAction == null) return;

            float horizontalMove = moveAction.ReadValue<Vector2>().x * horizontalSpeed;
            float verticalMove = moveAction.ReadValue<Vector2>().y * verticalSpeed;
            transform.position += new Vector3(horizontalMove, verticalMove, 0f) * Time.fixedDeltaTime;

            if (transform.position.x < minX) transform.position = new Vector3(minX, transform.position.y, transform.position.z);
            if (transform.position.x > maxX) transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
            if (transform.position.y < minY) transform.position = new Vector3(transform.position.x, minY, transform.position.z);
            if (transform.position.y > maxY) transform.position = new Vector3(transform.position.x, maxY, transform.position.z);

            transform.localScale = Vector3.one * sizeCurve.Evaluate((transform.position.y - minY) / (maxY - minY));

            if (moveAction.ReadValue<Vector2>() != Vector2.zero)
            {
                legsAnimator.SetBool("Moving", true);
            }
            else
            {
                legsAnimator.SetBool("Moving", false);
            }
        }
    }
}
