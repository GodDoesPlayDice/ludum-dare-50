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
        [SerializeField] private GameObject effectGameObject;
            #endregion

        #region Fields

        public InteractableType InteractableType { get; set; } = InteractableType.TowerPlace;
        private HUDController myHUDController;
        private BuildMenuController myBuildMenuController;
        private bool _towerSpawned = false;

        #endregion

        #region IInteractable

        public void ToBeingPointedMode()
        {
            if (_towerSpawned) return;
            transform.localScale = new Vector3(1, 3f, 1);
            effectGameObject.SetActive(true);
        }

        public void ToNotBeingPointedMode()
        {
            if (_towerSpawned) return;
            transform.localScale = Vector3.one;
            effectGameObject.SetActive(false);
        }

        public void Interact(Vector3? atPosition)
        {
            if (_towerSpawned) return;
            myHUDController.ToggleBuildMenu(true);
            myBuildMenuController = FindObjectOfType<BuildMenuController>();
            myBuildMenuController.currentTowerPlaceController = this;
        }

        #endregion

        #region MonoBehaviour

        private void Start()
        {
            myHUDController = FindObjectOfType<HUDController>();
        }

        public void SpawnTower(GameObject tower)
        {
            var spawnedTower = Instantiate(tower, spawnTowerTransform.position, spawnTowerTransform.rotation,
                spawnTowerTransform);
            meshRenderer.enabled = false;
            _towerSpawned = true;

            myHUDController.ToggleBuildMenu(false);

            spawnedTower.GetComponent<TowerController>().towerPlaceController = this;
        }

        public void DespawnTowerResponse()
        {
            meshRenderer.enabled = true;
            _towerSpawned = false;
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            var pos = transform.position;
            
            Gizmos.DrawLine(new Vector3(pos.x, 0.2f, pos.z), transform.position + transform.forward * 2f);
        }
#endif

        #endregion
    }
}