using System;
using __Game.Scripts.Actors;
using UnityEngine;

namespace __Game.Scripts.Environment
{
    public class ExitPlaceController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var mobController = other.gameObject.GetComponent<MobController>();
            if (mobController != null && mobController.productsRequire.Count > 0)
            {
                GameManager.Instance.LoseGame();
            }
        }
    }
}