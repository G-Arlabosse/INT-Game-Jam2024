using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitialazeUpgrades : MonoBehaviour
{
    public void Initialaze(TimeUpgrade[] upgrades, GameObject UIToSpawn, Transform spawnParent)
    {
        for (int i = 0; i < upgrades.Length; i++)
        {
            int currentIndex = i;

            GameObject go = Instantiate(UIToSpawn, spawnParent);

            //reset cost
            upgrades[currentIndex].CurrentUpgradeCost = upgrades[currentIndex].OriginalUpgradeCost;

            //set text
            Debug.Log(upgrades[currentIndex].CurrentUpgradeCost);
            UpgradeButtonReferences buttonRef = go.GetComponent<UpgradeButtonReferences>();
            buttonRef.UpgradeButtonText.text = upgrades[currentIndex].UpgradeButtonText;
            buttonRef.UpgradeButtonDescription.SetText(upgrades[currentIndex].UpgradeButtonDescription, upgrades[currentIndex].UpgradeAmount);
            buttonRef.UpgradeCostText.text = "Cost :" + upgrades[currentIndex].CurrentUpgradeCost;
            buttonRef.UpgradeImage.sprite = upgrades[currentIndex].UpgradeImage;
            
            

            //set onClick
            buttonRef.UpgradeButton.onClick.AddListener(delegate { TimeManager.instance.OnUpgradeButtonClick(upgrades[currentIndex], buttonRef); });
        }
    }
}
