using System;
using __Game.Scripts.Interfaces;
using __Game.Scripts.UI;
using UnityEngine;

namespace __Game.Scripts.Towers
{
    public class TowerPlaceController : MonoBehaviour, IInteractable
    {
        [SerializeField] private Transform spawnTowerTransform;
        
        public InteractableType InteractableType { get; set; } = InteractableType.TowerPlace;
        public bool IsBeingPointed { get; set; } = false;

        #region Field

        private HUDController myHUDController;
        private BuildMenuController myBuildMenuController;

        #endregion

        #region MonoBehaviour

        private void Start()
        {
            myHUDController = FindObjectOfType<HUDController>();
        }

        public void ToBeingPointedMode()
        {
            transform.localScale = new Vector3(1, 2f, 1);
        }

        public void ToNotBeingPointedMode()
        {
            transform.localScale = Vector3.one;
        }
        public void Interact(Vector3? atPosition)
        {
            myHUDController.ShowBuildMenu();
            myBuildMenuController = FindObjectOfType<BuildMenuController>();
            myBuildMenuController.currentTowerPlaceController = this;
        }
        
        public void SpawnTower(GameObject tower)
        {
            Instantiate(tower, spawnTowerTransform.position, spawnTowerTransform.rotation, spawnTowerTransform);
        }

        #endregion
        
        
    }
}