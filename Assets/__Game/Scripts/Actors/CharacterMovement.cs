using System;
using UnityEngine;
using UnityEngine.AI;

namespace __Game.Scripts.Actors
{
    public class CharacterMovement : MonoBehaviour
    {
        #region Inspector

        [Space] [Header("References to other objects and components")] [Space] 
        [SerializeField] private Animator animator;
        [SerializeField] private NavMeshAgent navMeshAgent;
        public Transform target;

        [Space] [Header("Settings")] [Space] [SerializeField]
        private bool followTarget = true;

        [SerializeField] private float navMeshSpeed = 3f;

        #endregion

        #region Fields

        private static readonly int Walking = Animator.StringToHash("walking");

        #endregion

        #region MonoBehaviour

        private void Start()
        {
            navMeshAgent.speed = navMeshSpeed;
        }

        private void FixedUpdate()
        {
            var distToTarget = Vector2.Distance(new Vector2(transform.position.x, transform.position.z),
                new Vector2(target.position.x, target.position.z));
            if (followTarget && distToTarget > 0.1f)
            {
                if (!navMeshAgent.enabled) navMeshAgent.enabled = true;
                animator.SetBool(Walking, true);
                navMeshAgent.destination = target.position;
            }
            else
            {
                animator.SetBool(Walking, false);
                navMeshAgent.enabled = false;
            }
        }

        #endregion
    }
}