using System;
using __Game.Scripts.UI;
using UnityEngine;

namespace __Game.Scripts
{
    public enum GameStates
    {
        Gameplay,
        Pause
    }
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public GameStates GameState { get; private set; }

        private HUDController hudController;

        private void Awake()
        {
            if (Instance != null && Instance != this) 
            { 
                Destroy(this); 
            } 
            else 
            { 
                Instance = this; 
            }
            
            hudController = FindObjectOfType<HUDController>();
        }

        private void Start()
        {
            StartGameplay();
        }


        public void LoseGame()
        {
            Time.timeScale = 0f;
            hudController.ToggleDeathMenu(true);
        }
        
        public void StartGameplay()
        {
            GameState = GameStates.Gameplay;
            Time.timeScale = 1f;
        }

        public void TogglePause()
        {
            if (GameState == GameStates.Pause)
            {
                GameState = GameStates.Gameplay;
                hudController.TogglePauseMenu(false);
                Time.timeScale = 1f;
            } else if (GameState == GameStates.Gameplay)
            {
                GameState = GameStates.Pause;
                hudController.TogglePauseMenu(true);
                Time.timeScale = 0f;
            }
        }
    }
}