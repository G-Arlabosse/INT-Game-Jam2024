using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class rotationAiguilles : MonoBehaviour
{
    [SerializeField] private Image minutes;
    [SerializeField] private Image heures;
    private int i=0;
    private int tic = 0;

    [SerializeField] GameObject audiomanager;
    private AudioManager audioman;

    public void ClickHorloge()
    {
        audioman = audiomanager.GetComponent<AudioManager>();
        if (tic == 0)
        {
            audioman.PlaySound(11);
            tic = 1;
        }
        else
        {
            audioman.PlaySound(12);
            tic = 0;
        }
        minutes.rectTransform.Rotate(Vector3.forward, -6);
        heures.rectTransform.Rotate(Vector3.forward, (float)-0.5);
        i++;
        if (i % 60 == 0)
        {
            audioman.PlaySound(13);
            TimeManager.instance.CurrentTimeCount += TimeManager.instance.CurrentTimePerSecond * 15;
            TimeManager.instance.TimeMultipler *= Math.Pow(1.018, 1 + Math.Log10(Math.Max(1, TimeManager.instance.singularities)));

        }
        if (i % 720 == 0)
        {
            audioman.PlaySound(14);
            TimeManager.instance.CurrentTimePerSecond = TimeManager.instance.CurrentTimePerSecond * 1.2;
            TimeManager.instance.TimeMultipler *= Math.Pow(1.3, 1 + Math.Log10(Math.Max(1, TimeManager.instance.singularities)));
        }
    }
}
