using UnityEngine;
using UnityEngine.UI;

namespace __Game.Scripts.UI
{
    public class TowerBuyButtonController : MonoBehaviour
    {
        [SerializeField] private GoodType goodsSO;
        [SerializeField] private Image goodsIcon;

        private BuildMenuController myBuildMenuController;
        private void Start()
        {
            myBuildMenuController = FindObjectOfType<BuildMenuController>();
            goodsIcon.sprite = goodsSO.icon;
        }

        public void BuyTower()
        {
            if (PlayerMoney.Instance.CurrentMoney >= goodsSO.baseTowerBuyPrice)
            {
                PlayerMoney.Instance.AddMoney(-goodsSO.baseTowerBuyPrice);
                myBuildMenuController.OnTowerButtonPressed(goodsSO.towerPrefab);
            }
        }
    }
}