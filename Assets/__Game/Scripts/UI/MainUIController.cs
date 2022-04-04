using UnityEngine;

namespace __Game.Scripts.UI
{
    public class MainUIController : MonoBehaviour
    {
        public GameObject mainScreen;
        public GameObject howToPlayScreen;
        public GameObject creditsScreen;

        public LoadSceneEvent loadSceneEvent;

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
            var ep = new LoadSceneEP(SceneEnum.GAME, SceneEnum.TITLE, active: true);
            loadSceneEvent.Raise(ep);
        }

        public void OnBackButtonPressed()
        {
            mainScreen.SetActive(true);
            creditsScreen.SetActive(false);
            howToPlayScreen.SetActive(false);
        }
    }
}