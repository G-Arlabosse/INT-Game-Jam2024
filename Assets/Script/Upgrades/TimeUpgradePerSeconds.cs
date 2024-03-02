using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Time Upgrades/Time Per Seconds", fileName ="Time Per Seoncds")]
public class TimeUpgradePerSeconds : TimeUpgrade
{

    public override void ApplyUpgrade()
    {
        GameObject go = Instantiate(TimeManager.instance.TimePerSecondObjToSpawn, Vector3.zero, Quaternion.identity);
        go.GetComponent<TimePerSecondsTimer>().TimePerSeconds = UpgradeAmount;

        TimeManager.instance.SimpleCookiePerSecondIncrease(UpgradeAmount);
    }

}
