using UnityEngine;

namespace __Game.Scripts.UI
{
    public class DeathScreenController : MonoBehaviour
    {
        public LoadSceneEvent loadSceneEvent;
        public void OnMainMenuButtonPressed()
        {
            var ep = new LoadSceneEP(SceneEnum.TITLE, SceneEnum.GAME, active: true);
            loadSceneEvent.Raise(ep);
        }

        public void OnRestartButtonPressed()
        {
            var ep = new LoadSceneEP(SceneEnum.GAME, SceneEnum.GAME, active: true);
            loadSceneEvent.Raise(ep);
        }
    }
}