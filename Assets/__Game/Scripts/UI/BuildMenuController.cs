using __Game.Scripts.Towers;
using UnityEngine;

namespace __Game.Scripts.UI
{
    public class BuildMenuController : MonoBehaviour
    {
        [HideInInspector] public TowerPlaceController currentTowerPlaceController;
        
        public void OnTowerButtonPressed(GameObject tower)
        {
            currentTowerPlaceController.SpawnTower(tower);
        }
    }
}