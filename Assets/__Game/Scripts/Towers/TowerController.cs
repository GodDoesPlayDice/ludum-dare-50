using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using __Game.Scripts.Interfaces;
using __Game.Scripts.UI;
using UnityEngine;
using UnityEngine.Animations;

namespace __Game.Scripts.Towers
{
    public class TowerController : MonoBehaviour, IInteractable
    {
        #region Inspector

        [SerializeField] private MeshRenderer attackRadiusMeshRenderer;

        [Space] [Header("Combat settings")] [Space] [SerializeField]
        private float baseAttackRadius = 3;

        [SerializeField] private Transform shootPoint;

        [SerializeField] private Transform aimingObjectTransform;

        [SerializeField] private GameObject projectile;

        [SerializeField] private float projectileSpeed;

        [SerializeField] private float baseAttackRate = 1f;

        #endregion

        #region Fields

        private Transform exitTransform;
        public InteractableType InteractableType { get; set; } = InteractableType.Tower;
        [HideInInspector] public TowerPlaceController towerPlaceController;

        private HUDController myHUDController;
        private TowerMenuController myTowerMenuController;

        // combat fields
        public List<GameObject> enemies;
        private GameObject closestToExitEnemy;
        private float currentAttackRate;
        private float currentAttackRadius;

        #endregion

        #region IInteractable

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

        #region MonoBehaviour

        private void Awake()
        {
            exitTransform = GameObject.Find("ExitPos").transform;
            myHUDController = FindObjectOfType<HUDController>();
            enemies = new List<GameObject>();
        }

        private void Start()
        {
            currentAttackRate = baseAttackRate;
            currentAttackRadius = baseAttackRadius;
            StartCoroutine(ShootingCoroutine());
        }

        private void FixedUpdate()
        {
            if (enemies.Count > 0 && enemies.Any(gameObj => gameObj != null))
            {
                closestToExitEnemy = GetClosestToExitEnemy();
                var dir = (closestToExitEnemy.transform.position - transform.position).normalized;
                aimingObjectTransform.rotation = Quaternion.LookRotation(Vector3.Lerp(aimingObjectTransform.forward, dir, 0.1f), Vector3.up);
            }
            else
            {
                closestToExitEnemy = null;
            }
        }

        public void DespawnTower()
        {
            Destroy(gameObject);
            towerPlaceController.DespawnTowerResponse();
            myHUDController.ToggleTowerMenu(false);
        }

        private IEnumerator ShootingCoroutine()
        {
            for (;;)
            {
                if (closestToExitEnemy != null)
                {
                    Shoot(closestToExitEnemy.transform.position);
                }

                yield return new WaitForSeconds(currentAttackRate);
            }
        }

        private GameObject GetClosestToExitEnemy()
        {
            GameObject closestToExit = null;
            for (var i = 0; i < enemies.Count; i++)
            {
                var currentEnemy = enemies[i];
                if (closestToExit == null) closestToExit = currentEnemy;
                var currentDist = Vector3.Distance(currentEnemy.transform.position, exitTransform.position);
                if (closestToExit != null &&
                    currentDist < Vector3.Distance(closestToExit.transform.position, exitTransform.position))
                {
                    closestToExit = currentEnemy;
                }
            }

            return closestToExit;
        }

        private void Shoot(Vector3 target)
        {
            var spawnedProjectile = Instantiate(projectile, shootPoint.transform.position,
                shootPoint.transform.rotation, shootPoint);
            var rb = spawnedProjectile.GetComponent<Rigidbody>();
            var dir = (target - shootPoint.transform.position).normalized;
            rb.velocity = dir * projectileSpeed;
        }

        #endregion
    }
}