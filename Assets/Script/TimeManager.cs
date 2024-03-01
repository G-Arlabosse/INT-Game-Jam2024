using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;

    public GameObject MainGameCanvas;
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

    public double CurrentTimeperSecond { get; set; }

    //upgrades

    public double TimePerClickUpgrade { get; set; }
}
