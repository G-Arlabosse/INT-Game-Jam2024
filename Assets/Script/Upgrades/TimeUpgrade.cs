using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class TimeUpgrade : ScriptableObject
{
    public float UpgradeAmount = 1f;

    public double OriginalUpgradeCost = 100;
    public double CurrentUpgradeCost = 100;
    public double CostIncreaseMultiplierPerPurchase = 0.05f;

    public string UpgradeButtonText;
    [TextArea(3, 10)]
    public string UpgradeButtonDescription;
    public Sprite UpgradeImage;
    public int UpgradeID;
    public abstract void ApplyUpgrade();


    private void OnValidate()
    {
        CurrentUpgradeCost = OriginalUpgradeCost;
    }
}
