using System;
using UnityEngine;

namespace __Game.Scripts.UI
{
    public class UILookAtCamera : MonoBehaviour
    {
        private void LateUpdate()
        {
            if (Camera.main == null) return;
            var camRot = Camera.main.transform.rotation;
            transform.LookAt(transform.position + camRot * Vector3.forward, camRot * Vector3.up);
        }
    }
}