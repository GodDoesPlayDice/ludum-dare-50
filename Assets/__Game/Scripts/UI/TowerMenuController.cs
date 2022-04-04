using __Game.Scripts.Towers;
using UnityEngine;

namespace __Game.Scripts.UI
{
    public class TowerMenuController : MonoBehaviour
    {
        [HideInInspector] public TowerController currentTowerController;

        public void OnSellButtonPressed()
        {
            currentTowerController.OnDespawnTowerClicked();
        }

        public void OnUpgradeButtonPressed()
        {
            
        }
    }
}