using System;
using __Game.Scripts.Interfaces;
using __Game.Scripts.UI;
using UnityEngine;

namespace __Game.Scripts.Towers
{
    public class TowerController : MonoBehaviour, IInteractable
    {
        #region Inspector

        [SerializeField] private GameObject projectile;
        [SerializeField] private MeshRenderer attackRadiusMeshRenderer;
        
        [Space]
        [Header("Combat settings")] 
        [Space]
        
        [SerializeField] private float baseAttackRadius = 3;
        [SerializeField] private float baseAttackRate = 1f;

        #endregion

        #region Fields

        public InteractableType InteractableType { get; set; } = InteractableType.Tower;
        public TowerPlaceController towerPlaceController;
        
        private HUDController myHUDController;
        private TowerMenuController myTowerMenuController;

        #endregion

        #region MonoBehaviour

        private void Start()
        {
            myHUDController = FindObjectOfType<HUDController>();
        }

        public void DespawnTower()
        {
            Destroy(gameObject);
            towerPlaceController.DespawnTowerResponse();
            myHUDController.ToggleTowerMenu(false);
        }

        public void ToBeingPointedMode()
        {
            attackRadiusMeshRenderer.enabled = true;
        }

        public void ToNotBeingPointedMode()
        {
            attackRadiusMeshRenderer.enabled = false;
        }

        public void Interact(Vector3? atPosition)
        {
            myHUDController.ToggleTowerMenu(true);
            myTowerMenuController = FindObjectOfType<TowerMenuController>();
            myTowerMenuController.currentTowerController = this;
        }

        #endregion
    }
}