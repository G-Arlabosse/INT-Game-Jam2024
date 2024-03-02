using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Timeline;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;

    public GameObject MainGameCanvas;
    [SerializeField] private GameObject _upgradeCanvas;
    [SerializeField] private TextMeshProUGUI _TimeCountText;
    [SerializeField] private TextMeshProUGUI _TimeCountperSECText;
    [SerializeField] private GameObject _TachyonObj;
    public GameObject TachyonTextPopup;
    [SerializeField] private GameObject _backgroundObj;

    [Space]
    public TimeUpgrade[] TimeUpgrades;
    [SerializeField] private GameObject _upgradeUIToSpawn;
    [SerializeField] private Transform _upgradeUIParent;
    public GameObject TimePerSecondObjToSpawn;

    [Space]
    [SerializeField] private GameObject _Clickable2;
    [SerializeField] private GameObject _Clickable3;
    [SerializeField] private GameObject _Clickable4;
    [SerializeField] private GameObject _Clickable5;
    [SerializeField] private GameObject _Clickable6;
    [SerializeField] private GameObject _Clickable7;

    public double CurrentTimeCount { get; set; }

    public double CurrentTimePerSecond { get; set; }

    //upgrades

    public double TimePerClickUpgrade { get; set; }

    private InitialazeUpgrades _initializeUpgrade;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        UpdateTimeUI();
        UpdateTimePerSecondUI();

        _upgradeCanvas.SetActive(false);
        MainGameCanvas.SetActive(true);
        _Clickable2.SetActive(false);

        _initializeUpgrade = GetComponent<InitialazeUpgrades>();
        _initializeUpgrade.Initialaze(TimeUpgrades, _upgradeUIToSpawn, _upgradeUIParent);
    }

    #region UI Updates

    private void UpdateTimeUI()
    {
        _TimeCountText.text = CurrentTimeCount.ToString();
    }

    private void UpdateTimePerSecondUI()
    {
        _TimeCountperSECText.text = CurrentTimePerSecond.ToString() + " P/S";
    }
   
    #endregion

    #region On Tachyon Clicked

    public void OnTachyonClicked()
    {
        IncreaseTime();

        _TachyonObj.transform.DOBlendableScaleBy(new Vector3(0.05f, 0.05f, 0.05f), 0.05f).OnComplete(TachyonScaleBack);
        _backgroundObj.transform.DOBlendableScaleBy(new Vector3(0.05f, 0.05f, 0.05f), 0.05f).OnComplete(BackgroudScaleBack);
    }

    private void TachyonScaleBack()
    {
        _TachyonObj.transform.DOBlendableScaleBy(new Vector3(-0.05f, -0.05f, -0.05f), 0.05f);

    }
    private void BackgroudScaleBack()
    {
        _backgroundObj.transform.DOBlendableScaleBy(new Vector3(-0.05f, -0.05f, -0.05f), 0.05f);
    }
    public void IncreaseTime()
    {
        CurrentTimeCount = 1+ (1*TimePerClickUpgrade) + CurrentTimeCount;
        UpdateTimeUI();
    }
    #endregion

    #region Button Presses

    public void OnUpgradeButtonPress()
    {
        MainGameCanvas.SetActive(false);
        _upgradeCanvas.SetActive(true);
    }

    public void OnResumeButtonPress()
    {
        _upgradeCanvas.SetActive(false);
        MainGameCanvas.SetActive(true);
    }

    #endregion

    #region Simple Increase

    public void SimpleTimeIncrease(double amount)
    {
        CurrentTimeCount += amount;
        UpdateTimeUI();
    }

    public void SimpleCookiePerSecondIncrease(double amount)
    {
        CurrentTimePerSecond += amount;
        UpdateTimePerSecondUI();
    }

    #endregion

    #region Events

    public void OnUpgradeButtonClick(TimeUpgrade upgrade, UpgradeButtonReferences buttonRef)
    {
        if (CurrentTimeCount >= upgrade.CurrentUpgradeCost)
        {
            upgrade.ApplyUpgrade();

            CurrentTimeCount -= upgrade.CurrentUpgradeCost;
            UpdateTimeUI();

            upgrade.CurrentUpgradeCost = Mathf.Round((float)(upgrade.CurrentUpgradeCost * (1 + upgrade.CostIncreaseMultiplierPerPurchase)));

            buttonRef.UpgradeCostText.text = "Cost: " + upgrade.CurrentUpgradeCost;
        }
    }

    #endregion

    #region Nouvel Objet

    public void Apparition(int ID)
    {
        if(ID == 1)
        {
            _Clickable2.SetActive(true);
        }
        if (ID == 2)
        {
            _Clickable3.SetActive(true);
        }
        if(ID == 3)
        {
            _Clickable4.SetActive(true);
        }
        if(ID == 1)
        {
            _Clickable5.SetActive(true);
        }
        if(ID == 5)
        {
            _Clickable6.SetActive(true);
        }
        if (ID == 6)
        {
            _Clickable7.SetActive(true);
        }
    }

    #endregion
}
