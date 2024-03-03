using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;

    public GameObject MainGameCanvas;
    [SerializeField] private GameObject _upgradeCanvas;
    [SerializeField] private TextMeshProUGUI _TimeCountText;
    [SerializeField] private TextMeshProUGUI _TimeCountperSECText;
    [SerializeField] private TextMeshProUGUI _TimeMultiplierTXT;
    [SerializeField] private TextMeshProUGUI _TimeRebirthTXT;
    [SerializeField] private TextMeshProUGUI _TimeRebirtBufferTXT;
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

    [Space]
    [SerializeField] private GameObject _RebirthButton;
    public double CurrentTimeCount { get; set; }

    public double CurrentTimePerSecond { get; set; }

    public double TimeMultipler { get; set; }

    //upgrades

    public double TimePerClickUpgrade { get; set; }

    private InitialazeUpgrades _initializeUpgrade;

    
    private double rebirthMultiplier;
    private double rebirthBuffer;
    private double rebirthTimeBefore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            TimeMultipler = 1;
        }

        UpdateTimeUI();
        UpdateTimePerSecondUI();
        UpdateTimeMultiplierUI();

        _upgradeCanvas.SetActive(false);
        MainGameCanvas.SetActive(true);
        _Clickable2.SetActive(false);
        _Clickable3.SetActive(false);
        _Clickable4.SetActive(false);
        _Clickable5.SetActive(false);
        _Clickable6.SetActive(false);
        _Clickable7.SetActive(false);
        _RebirthButton.SetActive(false);
        _TimeRebirtBufferTXT.enabled = false;
        _TimeRebirthTXT.enabled = false;

        _initializeUpgrade = GetComponent<InitialazeUpgrades>();
        _initializeUpgrade.Initialaze(TimeUpgrades, _upgradeUIToSpawn, _upgradeUIParent);
    }

    #region UI Updates

    private void UpdateTimeUI()
    {
        _TimeCountText.text = Math.Round(CurrentTimeCount).ToString() +" Tachyons";
        UpdateTimeMultiplierUI();
        TimeRebirtCount();
    }

    private void UpdateTimePerSecondUI()
    {
        _TimeCountperSECText.text = Math.Round(CurrentTimePerSecond, 1).ToString() + " Tachyons/s";
    }

    private void UpdateTimeMultiplierUI()
    {
        _TimeMultiplierTXT.text = "Multplicateur : " + Math.Round(TimeMultipler, 3).ToString();
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
        CurrentTimeCount += (1+ TimePerClickUpgrade);
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
        CurrentTimeCount += amount*TimeMultipler*(1+rebirthMultiplier*2);
        UpdateTimeUI();
    }

    public void SimpleCookiePerSecondIncrease(double amount)
    {
        CurrentTimePerSecond += amount * TimeMultipler * (1 + rebirthMultiplier * 2) ;
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
        if (ID == 1)
        {
            _Clickable3.SetActive(true);
        }
        if(ID == 1)
        {
            _Clickable4.SetActive(true);
        }
        if(ID == 1)
        {
            _Clickable5.SetActive(true);
        }
        if(ID == 1)
        {
            _Clickable6.SetActive(true);
        }
        if (ID == 1)
        {
            _Clickable7.SetActive(true);
        }
    }

    #endregion

    #region Rebirt System

    private void TimeRebirtCount()
    {
        if(Math.Round(CurrentTimeCount) >100 && CurrentTimePerSecond > 1)
        {
            rebirthBuffer = Math.Round(CurrentTimeCount/(100*(1+(rebirthMultiplier*0.1)))); 
            _TimeRebirtBufferTXT.text = "Waiting Singularities :" + rebirthBuffer.ToString();
            _RebirthButton.SetActive(true);
            _TimeRebirtBufferTXT.enabled = true;
            _TimeRebirthTXT.enabled = true;
            _TimeRebirthTXT.text = rebirthMultiplier.ToString() + " Singularities";
        }
    }

    public void TimeRebirthValidate()
    {
        rebirthTimeBefore += CurrentTimePerSecond;
        rebirthMultiplier += rebirthBuffer;
        rebirthBuffer = 0;
        CurrentTimeCount = 0; 
        _initializeUpgrade = GetComponent<InitialazeUpgrades>();
        _initializeUpgrade.Initialaze(TimeUpgrades, _upgradeUIToSpawn, _upgradeUIParent);
        _Clickable2.SetActive(false);
        _Clickable3.SetActive(false);
        _Clickable4.SetActive(false);
        _Clickable5.SetActive(false);
        _Clickable6.SetActive(false);
        _Clickable7.SetActive(false);
        _TimeRebirthTXT.text = rebirthMultiplier.ToString() + " Singularities";
    }


    #endregion
}
