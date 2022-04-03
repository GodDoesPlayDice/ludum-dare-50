using UnityEngine;

namespace __Game.Scripts.UI
{
    public class HUDController : MonoBehaviour
    {
        #region Inspector

        [SerializeField] private GameObject buildMenu;

        #endregion


        #region MonoBehaviour

        public void ToggleBuildMenu(bool enable)
        {
            buildMenu.SetActive(enable);
        }

        #endregion
        
    }
}