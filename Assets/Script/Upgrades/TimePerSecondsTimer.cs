using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class TimePerSecondsTimer : MonoBehaviour
{
    public float TimerDuration = 1f;

    public double TimePerSeconds {  get; set; }

    private float _counter;

    private void Update()
    {
        _counter += Time.deltaTime;
        
        if(_counter >= TimerDuration)
        {
            TimeManager.instance.SimpleTimeIncrease(TimePerSeconds);
            
            _counter = 0;
        }
    }
}
