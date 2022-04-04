using System;
using TMPro;
using UnityEngine;

namespace __Game.Scripts.UI
{
    public class GameplayUIController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI moneyAmountTMP;
        private void Awake()
        {
            PlayerMoney.Instance.OnCurrentMoneyChanged.AddListener(CurrentMoneyChanged);
        }

        private void CurrentMoneyChanged(int newVal)
        {
            moneyAmountTMP.text = $"{newVal}$";
        }
    }
}