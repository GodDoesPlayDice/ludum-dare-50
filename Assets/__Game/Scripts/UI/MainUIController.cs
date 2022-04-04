using UnityEngine;

namespace __Game.Scripts.UI
{
    public class MainUIController : MonoBehaviour
    {
        public GameObject mainScreen;
        public GameObject howToPlayScreen;
        public GameObject creditsScreen;

        

        public void OnCreditsScreenButtonPressed()
        {
            creditsScreen.SetActive(true);
            howToPlayScreen.SetActive(false);
            mainScreen.SetActive(false);
        }
        
        public void OnHowToPlayScreenButtonPressed()
        {
            howToPlayScreen.SetActive(true);
            creditsScreen.SetActive(false);
            mainScreen.SetActive(false);
        }

        public void OnPlayNewGameButtonPressed()
        {
            
        }

        public void OnBackButtonPressed()
        {
            mainScreen.SetActive(true);
            creditsScreen.SetActive(false);
            howToPlayScreen.SetActive(false);
        }
    }
}