using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
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

    [SerializeField] GameObject audiomanager;
    private AudioManager audioman;

    //upgrades

    public double TimePerClickUpgrade { get; set; }

    private InitialazeUpgrades _initializeUpgrade;

    public float TimerDuration = 1f;
    private double _counter;

    public double singularities;
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
        audioman = audiomanager.GetComponent<AudioManager>();
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
        audioman.PlaySound(2);
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
        audioman.PlaySound(1);
        MainGameCanvas.SetActive(false);
        _upgradeCanvas.SetActive(true);
    }

    public void OnResumeButtonPress()
    {
        audioman.PlaySound(1);
        _upgradeCanvas.SetActive(false);
        MainGameCanvas.SetActive(true);
    }

    #endregion

    #region Simple Increase

    public void SimpleTimeIncrease(double amount)
    {
        CurrentTimeCount += amount*TimeMultipler;
        UpdateTimeUI();
    }

    public void SimpleCookiePerSecondIncrease(double amount)
    {
        CurrentTimePerSecond += amount ;
        UpdateTimePerSecondUI();
    }

    #endregion

    #region Events

    public void OnUpgradeButtonClick(TimeUpgrade upgrade, UpgradeButtonReferences buttonRef)
    {
        audioman.PlaySound(1);
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
        if(ID == 4)
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

    #region Rebirt System

    private void TimeRebirtCount()
    {
        if(Math.Round(CurrentTimeCount) > 100)
        {
            rebirthBuffer = Math.Floor(CurrentTimeCount/100); 
            _TimeRebirtBufferTXT.text = "Waiting Singularities :" + rebirthBuffer.ToString();
            _RebirthButton.SetActive(true);
            _TimeRebirtBufferTXT.enabled = true;
            _TimeRebirthTXT.enabled = true;
            _TimeRebirthTXT.text = singularities.ToString() + " Singularities";
        }
    }

    public void TimeRebirthValidate()
    {
        audioman.PlaySound(17);
        rebirthTimeBefore += CurrentTimePerSecond;
        singularities += rebirthBuffer;
        rebirthBuffer = 0;
        CurrentTimeCount = 0;
        CurrentTimePerSecond = 0;
        TimePerClickUpgrade = 0;
        TimeMultipler = 1;

        _initializeUpgrade = GetComponent<InitialazeUpgrades>();
        // Reset prices of upgrades and upgrade text
        for (int i = 0; i < TimeUpgrades.Length; i++)
        {
            TimeUpgrades[i].CurrentUpgradeCost = TimeUpgrades[i].OriginalUpgradeCost; // Reset cost
        }





        _Clickable2.SetActive(false);
        _Clickable3.SetActive(false);
        _Clickable4.SetActive(false);
        _Clickable5.SetActive(false);
        _Clickable6.SetActive(false);
        _Clickable7.SetActive(false); 
        _RebirthButton.SetActive(false);
        _TimeCountperSECText.text = Math.Round(CurrentTimePerSecond, 1).ToString() + " Tachyons/s";
        _TimeRebirtBufferTXT.text = "Waiting Singularities : 0";
        _TimeRebirthTXT.text = singularities.ToString() + " Singularities";
    }


    #endregion

    public void Update()
    {
        _counter += Time.deltaTime;

        if (_counter >= 0.1)
        {
            SimpleTimeIncrease(CurrentTimePerSecond/10);

            _counter = 0;
        }
    }
}
