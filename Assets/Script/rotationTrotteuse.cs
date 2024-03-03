using System.Collections;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class rotationTrotteuse : MonoBehaviour
{
    [SerializeField] private Image trotteuse;
    private float clickCount;
    private float timer = 0f;
    private bool isFunctionActive = true;

    [SerializeField] GameObject audiomanager;
    private AudioManager audioman;

    public void ClickChrono()
    {
        audioman = audiomanager.GetComponent<AudioManager>();
        trotteuse.rectTransform.Rotate(Vector3.forward, -6f);
        audioman.PlaySound(7);
        if (isFunctionActive == true)
        {
            clickCount += 1;
        }
    }

    public void Update()
    {
        if (isFunctionActive == true) {
            timer += Time.deltaTime ;
            if(timer > 60f)
            {
                isFunctionActive = false;
                audioman.PlaySound(8);
                TimeManager.instance.CurrentTimeCount += clickCount * TimeManager.instance.CurrentTimePerSecond / 2;
                TimeManager.instance.TimeMultipler *= Math.Pow(1.04, 1 + Math.Log10(Math.Max(1, TimeManager.instance.singularities)));
                isFunctionActive = false;
            }
        }
    }
}
