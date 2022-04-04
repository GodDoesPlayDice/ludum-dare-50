using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using __Game.Scripts.Actors;
using __Game.Scripts.Interfaces;
using __Game.Scripts.UI;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

namespace __Game.Scripts.Towers
{
    public class TowerController : MonoBehaviour, IInteractable
    {
        #region Inspector

        public GoodType goodsSO;

        [SerializeField] private SpriteRenderer goodsSprite;
        [SerializeField] private Animator animator;
        [SerializeField] private MeshRenderer attackRadiusMeshRenderer;

        [Space] [Header("Combat settings")] [Space] [SerializeField]
        private float baseAttackRadius = 3;

        public Transform shootPoint;

        [SerializeField] private Transform aimingObjectTransform;

        public GameObject projectile { get; private set; }

        public float projectileSpeed;

        [SerializeField] private float baseAttackRate = 1f;

        #endregion

        #region Fields

        public int currentLevel;
        public int currentSellPrice;
        public int currentUpgradePrice;

        public InteractableType InteractableType { get; set; } = InteractableType.Tower;
        [HideInInspector] public TowerPlaceController towerPlaceController;

        private HUDController myHUDController;
        private TowerMenuController myTowerMenuController;

        // combat fields
        public List<GameObject> enemiesInAttackRadius;
        private GameObject currentTargetMob;
        public Vector3 currentShootDir;
        private float currentAttackRate;
        private static readonly int ShootAnimation = Animator.StringToHash("shoot");
        private static readonly int ShootSpeedAnim = Animator.StringToHash("shoot speed");
        private static readonly int Spawn = Animator.StringToHash("spawn");
        private static readonly int Despawn = Animator.StringToHash("despawn");

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
            myHUDController = FindObjectOfType<HUDController>();
            enemiesInAttackRadius = new List<GameObject>();
        }

        private void Start()
        {
            currentAttackRate = baseAttackRate;
            StartCoroutine(ShootingCoroutine());
            animator.SetTrigger(Spawn);

            goodsSprite.sprite = goodsSO.icon;
            projectile = goodsSO.prefabWithModel;

            currentLevel = 1;
            currentSellPrice = goodsSO.baseTowerSellPrice;
            currentUpgradePrice = goodsSO.baseTowerUpgradePrice;
        }

        private void FixedUpdate()
        {
            currentTargetMob = GetCurrentTargetMob();
            if (currentTargetMob != null)
            {
                Aiming();
            }
        }

        private void Aiming()
        {
            var dir = (currentTargetMob.transform.position - transform.position).normalized;
            aimingObjectTransform.rotation =
                Quaternion.LookRotation(Vector3.Lerp(aimingObjectTransform.forward, dir, 0.1f), Vector3.up);
        }

        public void OnDespawnTowerClicked()
        {
            animator.SetTrigger(Despawn);
            myHUDController.ToggleTowerMenu(false);
        }

        public void DespawnTower()
        {
            Destroy(gameObject);
            towerPlaceController.DespawnTowerResponse();
        }

        public void UpgradeTower()
        {
            currentLevel++;
            var arrackRadius = attackRadiusMeshRenderer.gameObject;
            var attackRadiusScale = arrackRadius.transform.localScale;
            var newScaleVal = attackRadiusScale.x += attackRadiusScale.x * goodsSO.pricesPercentChangeThroughUpgrade / 100;
            arrackRadius.transform.localScale = new Vector3(newScaleVal, 0.2f, newScaleVal);
            projectileSpeed += projectileSpeed * goodsSO.pricesPercentChangeThroughUpgrade / 100;
            currentAttackRate -= currentAttackRate * goodsSO.pricesPercentChangeThroughUpgrade / 100;
            currentSellPrice += currentSellPrice * goodsSO.pricesPercentChangeThroughUpgrade / 100;
            currentUpgradePrice += currentUpgradePrice * goodsSO.pricesPercentChangeThroughUpgrade / 100;
        }

        private IEnumerator ShootingCoroutine()
        {
            for (;;)
            {
                animator.SetFloat(ShootSpeedAnim, 1 / currentAttackRate);

                if (GetCurrentTargetMob() != null)
                {
                    Shoot(currentTargetMob.transform.position);
                }

                yield return new WaitForSeconds(currentAttackRate);
            }
        }

        private GameObject GetCurrentTargetMob()
        {
            GameObject result = null;
            var lastNearestDist = 1000f;
            for (var i = 0; i < enemiesInAttackRadius.Count; i++)
            {
                var currentEntry = enemiesInAttackRadius[i];
                if (currentEntry != null)
                {
                    // check demand
                    var mobController = currentEntry.GetComponent<MobController>();
                    var hasDemand = mobController.productsRequire.ContainsKey(goodsSO);

                    // check distance
                    var isNearest = false;
                    var dist = Vector3.Distance(transform.position, currentEntry.transform.position);
                    if (dist < lastNearestDist)
                    {
                        isNearest = true;
                    }

                    if (hasDemand && isNearest) result = currentEntry;
                }
            }

            return result;
        }

        private void Shoot(Vector3 target)
        {
            target.y = 1.5f;
            currentShootDir = (target - shootPoint.transform.position).normalized;
            animator.SetTrigger(ShootAnimation);
        }

        #endregion
    }
}