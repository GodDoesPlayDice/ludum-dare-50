using System;
using __Game.Scripts.Interfaces;
using __Game.Scripts.UI;
using UnityEngine;

namespace __Game.Scripts.Towers
{
    public class TowerPlaceController : MonoBehaviour, IInteractable
    {
        #region Inspector

        [SerializeField] private Transform spawnTowerTransform;
        [SerializeField] private MeshRenderer meshRenderer;
        
        #endregion
        
        #region Fields
        
        public InteractableType InteractableType { get; set; } = InteractableType.TowerPlace;
        private HUDController myHUDController;
        private BuildMenuController myBuildMenuController;
        private bool _towerSpawned = false;

        #endregion

        #region MonoBehaviour

        private void Start()
        {
            myHUDController = FindObjectOfType<HUDController>();
        }

        public void ToBeingPointedMode()
        {
            if (_towerSpawned) return;
            transform.localScale = new Vector3(1, 2f, 1);
        }

        public void ToNotBeingPointedMode()
        {
            if (_towerSpawned) return;
            transform.localScale = Vector3.one;
        }
        public void Interact(Vector3? atPosition)
        {
            if (_towerSpawned) return;
            myHUDController.ToggleBuildMenu(true);
            myBuildMenuController = FindObjectOfType<BuildMenuController>();
            myBuildMenuController.currentTowerPlaceController = this;
        }
        
        public void SpawnTower(GameObject tower)
        {
            Instantiate(tower, spawnTowerTransform.position, spawnTowerTransform.rotation, spawnTowerTransform);
            meshRenderer.enabled = false;
            _towerSpawned = true;
            
            myHUDController.ToggleBuildMenu(false);
        }

        public void DespawnTower()
        {
            var tower = spawnTowerTransform.GetChild(0)?.gameObject;
            if (tower != null) Destroy(tower);
            meshRenderer.enabled = true;
            _towerSpawned = false;
        }

        #endregion
    }
}