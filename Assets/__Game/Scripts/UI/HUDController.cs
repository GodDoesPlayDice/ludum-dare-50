using UnityEngine;

namespace __Game.Scripts.UI
{
    public class HUDController : MonoBehaviour
    {
        #region Inspector

        [SerializeField] private GameObject[] allMenus;
        [SerializeField] private GameObject buildMenu;
        [SerializeField] private GameObject towerMenu;
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private GameObject deathMenu;
        
        #endregion


        #region MonoBehaviour

        public void ToggleBuildMenu(bool enable)
        {
            if (enable) DisableAllMenus();
            buildMenu.SetActive(enable);
        }

        public void ToggleTowerMenu(bool enable)
        {
            if (enable) DisableAllMenus();
            towerMenu.SetActive(enable);
        }

        public void TogglePauseMenu(bool enable)
        {
            if (enable) DisableAllMenus();
            pauseMenu.SetActive(enable);
        }
        
        public void ToggleDeathMenu(bool enable)
        {
            if (enable) DisableAllMenus();
            deathMenu.SetActive(enable);
        }

        private void DisableAllMenus()
        {
            foreach (var menu in allMenus)
            {
                menu.SetActive(false);
            }
        }

        #endregion
        
    }
}