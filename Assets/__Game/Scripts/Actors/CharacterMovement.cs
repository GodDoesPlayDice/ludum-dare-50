using System;
using UnityEngine;
using UnityEngine.AI;

namespace __Game.Scripts.Actors
{
    [RequireComponent(typeof(WaypointMovementController))]
    public class CharacterMovement : MonoBehaviour
    {
        #region Inspector

        [Space] [Header("References to other objects and components")] [Space] 
        [SerializeField] private Animator animator;
        [SerializeField] private NavMeshAgent navMeshAgent;
        public Vector3 target;

        [Space] [Header("Settings")] [Space] [SerializeField]
        private bool followTarget = true;

        [SerializeField] private float navMeshSpeed = 3f;

        #endregion

        #region Fields

        private static readonly int Walking = Animator.StringToHash("walking");
        private WaypointMovementController waypointMovementController;

        #endregion

        #region MonoBehaviour

        private void Start()
        {
            navMeshAgent.speed = navMeshSpeed;
            waypointMovementController = GetComponent<WaypointMovementController>();
        }

        private void FixedUpdate()
        {
            //Transform target = waypointMovementController.GetCurrentWaypoint().transform;

            var distToTarget = Vector2.Distance(new Vector2(transform.position.x, transform.position.z),
                new Vector2(target.x, target.z));
            if (followTarget && distToTarget > 0.5f)
            {
                if (!navMeshAgent.enabled) navMeshAgent.enabled = true;
                animator.SetBool(Walking, true);
                navMeshAgent.destination = target;
            }
            else
            {
                animator.SetBool(Walking, false);
                navMeshAgent.enabled = false;
                Destroy(gameObject);
            }
        }

        #endregion
    }
}