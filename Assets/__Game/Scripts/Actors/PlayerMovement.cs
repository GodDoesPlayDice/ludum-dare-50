using UnityEngine;

namespace __Game.Scripts.Actors
{
    public class PlayerMovement : MonoBehaviour
    {
        #region Inspector

        [SerializeField] private Animator animator;
        [SerializeField] [Range(0f, 400f)] private float movementSpeed = 5f;
        [SerializeField] [Range(0f, 3f)] private float accelerationTime = 1f;

        #endregion

        #region Fields

        private float horizontalInput = 0;
        private float accelerationPercent = 0;
        private float movementStartTime = 0;

        private Rigidbody myRb;
        private static readonly int AnimMovement = Animator.StringToHash("horizontal speed");
        private static readonly int Acceleration = Animator.StringToHash("acceleration");

        #endregion

        #region MonoBehaviour

        private void Awake()
        {
            myRb = GetComponent<Rigidbody>();
            Application.targetFrameRate = 60;
        }

        private void Update()
        {
            horizontalInput = Input.GetAxis("Horizontal");
            animator.SetFloat(AnimMovement, horizontalInput);
            if (horizontalInput == 0)
            {
                accelerationPercent = 0;
                movementStartTime = Time.time;
            }
            else
            {
                accelerationPercent = Mathf.Clamp01((Time.time - movementStartTime) / accelerationTime);
            }
            Debug.Log(accelerationPercent);
        }

        private void FixedUpdate()
        {
            var speed = horizontalInput * movementSpeed * accelerationPercent;
            if (horizontalInput != 0)
            {
                myRb.velocity = new Vector3(speed * Time.fixedDeltaTime, 0, 0);
            }
            else
            {
                myRb.velocity = Vector3.zero;
            }
                
        }

        #endregion
    }
}