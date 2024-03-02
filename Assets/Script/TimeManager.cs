using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
    [SerializeField] private GameObject _upgradeUIToSpawn;
    [SerializeField] private Transform _upgradeUIParent;
    public GameObject TimePerSecondObjToSpawn;


    public double CurrentTimeCount { get; set; }

    public double CurrentTimePerSecond { get; set; }

    //upgrades

    public double TimePerClickUpgrade { get; set; }

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
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        UpdateTimeUI();
        UpdateTimePerSecondUI();

        _upgradeCanvas.SetActive(false);
        MainGameCanvas.SetActive(true);
    }

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
        CurrentTimeCount = 1 + CurrentTimeCount;
        UpdateTimeUI();
    }
    #endregion

}
