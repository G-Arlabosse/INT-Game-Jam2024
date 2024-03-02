using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Time Upgrades/Time Per Click", fileName ="Time Per Click")]
public class TimeUpgradePerClick : TimeUpgrade
{
    public override void ApplyUpgrade()
    {
        TimeManager.instance.TimePerClickUpgrade += UpgradeAmount;
    }
}
