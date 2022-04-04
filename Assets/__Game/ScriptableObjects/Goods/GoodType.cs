using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName = "Custom/IngameObjects/GoodsType", order = 61)]
public class GoodType : ScriptableObject
{
    public string name;
    public Sprite icon;
    public GameObject prefabWithModel;
    public GameObject towerPrefab;
    public int baseTowerBuyPrice;
    public int baseTowerSellPrice;
    public int baseTowerUpgradePrice;
    public int pricesPercentChangeThroughUpgrade;
}
