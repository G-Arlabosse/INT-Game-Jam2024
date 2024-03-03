using System.Collections;
using System.Collections.Generic;
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

    public void FixedUpdate()
    {
        if (isFunctionActive == true) {
            timer += Time.deltaTime ;
            if(timer > 60f)
            {
                isFunctionActive = false ;
            }
            else
            {
                if(clickCount > 500)
                {
                    audioman.PlaySound(8);
                    TimeManager.instance.CurrentTimeCount = clickCount*TimeManager.instance.CurrentTimePerSecond/10;
                    TimeManager.instance.TimeMultipler += 0.1;
                    isFunctionActive = false;
                }
                else
                {
                   isFunctionActive = false;
                }
            }
            if(timer > 180f)
            {
                isFunctionActive = true ;
            }
        }
    }
}
