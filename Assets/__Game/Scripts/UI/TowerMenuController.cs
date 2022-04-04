using System;
using __Game.Scripts.Towers;
using TMPro;
using UnityEngine;

namespace __Game.Scripts.UI
{
    public class TowerMenuController : MonoBehaviour
    {
        [HideInInspector] public TowerController currentTowerController;

        [SerializeField] private TextMeshProUGUI towerNameTMP;
        [SerializeField] private TextMeshProUGUI towerLvlTMP;
        [SerializeField] private TextMeshProUGUI sellPriceTMP;
        [SerializeField] private TextMeshProUGUI upgradePriceTMP;


        private void FixedUpdate()
        {
            if (currentTowerController != null)
            {
                towerNameTMP.text = $"{currentTowerController.goodsSO.name} tower";
                towerLvlTMP.text = $"{currentTowerController.currentLevel.ToString()} lvl";
                sellPriceTMP.text = currentTowerController.currentSellPrice.ToString();
                upgradePriceTMP.text = currentTowerController.currentUpgradePrice.ToString();
            }
        }

        public void OnSellButtonPressed()
        {
            PlayerMoney.Instance.AddMoney(currentTowerController.currentSellPrice);
            currentTowerController.OnDespawnTowerClicked();
        }

        public void OnUpgradeButtonPressed()
        {
            if (PlayerMoney.Instance.CurrentMoney >= currentTowerController.currentUpgradePrice)
            {
                PlayerMoney.Instance.AddMoney(-currentTowerController.currentUpgradePrice);
                currentTowerController.UpgradeTower();
            }
        }
    }
}