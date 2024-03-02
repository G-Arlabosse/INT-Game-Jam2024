using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class rotationAiguilles : MonoBehaviour
{
    [SerializeField] private Image minutes;
    [SerializeField] private Image heures;
    private int i=0;

    public void ClickHorloge()
    {
        minutes.rectTransform.Rotate(Vector3.forward, -6);
        heures.rectTransform.Rotate(Vector3.forward, (float)-0.5);
        i++;
        if (i % 60 == 0)
        {
            TimeManager.instance.CurrentTimeCount += TimeManager.instance.CurrentTimePerSecond * 15;
            TimeManager.instance.TimeMultipler *= 1.05;

        }
        if (i % 720 == 0)
        {
            TimeManager.instance.CurrentTimePerSecond = TimeManager.instance.CurrentTimePerSecond * 1.2;
            TimeManager.instance.TimeMultipler *= 1.4;
        }
    }
}
