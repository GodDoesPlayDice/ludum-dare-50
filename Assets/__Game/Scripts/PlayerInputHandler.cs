using __Game.Scripts.UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace __Game.Scripts
{
    public class PlayerInputHandler : MonoBehaviour
    {
        private GameManager gameManager;

        public void OnPause(InputAction.CallbackContext context)
        {
            if (gameManager == null) gameManager = FindObjectOfType<GameManager>();
            if (context.performed)
            {
                gameManager.TogglePause();
            }
        }
    }
}