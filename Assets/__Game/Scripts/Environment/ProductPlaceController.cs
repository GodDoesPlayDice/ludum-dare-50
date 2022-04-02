using System;
using UnityEngine;

namespace __Game.Scripts.Environment
{
    public class ProductPlaceController : MonoBehaviour
    {
        [SerializeField] [Range(0f, 0.5f)] private float gizmoCubeSize = 0.1f;
        [SerializeField] private bool drawGizmos = false;
#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (drawGizmos)
            {
                Gizmos.color = Color.red / 2f;
                Gizmos.DrawCube(transform.position, new Vector3(gizmoCubeSize, gizmoCubeSize, gizmoCubeSize));
            }
        }
#endif
    }
}