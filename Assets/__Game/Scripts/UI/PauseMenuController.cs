using UnityEngine;

namespace __Game.Scripts.UI
{
    public class PauseMenuController : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        private GameManager myGameManager;
        public void OnHowToPlayButtonPressed()
        {
            
        }

        public void OnContinueButtonPressed()
        {
            if (myGameManager == null)
            {
                myGameManager = FindObjectOfType<GameManager>();
            }
            myGameManager.TogglePause();
        }
    }
}