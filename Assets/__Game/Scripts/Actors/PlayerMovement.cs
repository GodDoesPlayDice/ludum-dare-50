using System;
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

        #endregion

        #region MonoBehaviour

        private void Awake()
        {
            myRb = GetComponent<Rigidbody>();
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
        }

        private void FixedUpdate()
        {
            if (horizontalInput != 0)
                myRb.velocity = new Vector3(horizontalInput * movementSpeed * accelerationPercent * Time.fixedDeltaTime,
                    0, 0);
        }

        #endregion
    }
}