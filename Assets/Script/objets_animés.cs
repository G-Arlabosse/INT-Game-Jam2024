using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI; 

public class objets_animés : MonoBehaviour
{
    public int i = 0;
    public Texture2D text;
    public Image sp;
    public Sprite[] sprites;

    [SerializeField] GameObject audiomanager;
    private AudioManager audioman;

    public void Start()
    {
        sp = GetComponent<Image>();   
        sprites = Resources.LoadAll<Sprite>(text.name);
        sp.sprite = sprites[0];

        audioman = audiomanager.GetComponent<AudioManager>();

    }

    private void OnMouseDown()
    {

        i = i++ % (sprites.Length);
        sp.sprite = sprites[i];

      
    }


    public void changeSprite()
    {
        i = (i + 1) % sprites.Length;
        sp.sprite = sprites[i];
        print(sp.sprite);
        print(sprites[i]);
        print(i);
        if (sprites.Length == 6)
        {
            audioman.PlaySound(5);
            if (i % 6 == 0)
            {
                audioman.PlaySound(6);
                TimeManager.instance.CurrentTimeCount += TimeManager.instance.CurrentTimePerSecond * 2;
                TimeManager.instance.TimeMultipler *= 1.005;
            }
        }
        if (sprites.Length == 18)
        {
            audioman.PlaySound(9);
            if (i % 18 == 0)
            {
                audioman.PlaySound(10);
                TimeManager.instance.CurrentTimeCount += TimeManager.instance.CurrentTimePerSecond * 6;
                TimeManager.instance.TimeMultipler *= 1.01;
            }

        }
        if (sprites.Length == 35)
        {
            audioman.PlaySound(15);
            if (i % 35 == 0)
            {
                audioman.PlaySound(16);
                TimeManager.instance.CurrentTimeCount += TimeManager.instance.CurrentTimePerSecond * 15;
                TimeManager.instance.TimeMultipler *= 1.02;
            }
        }
        if (sprites.Length == 11)
        {
            audioman.PlaySound(3);
            if (i % 11 == 0)
            {
                audioman.PlaySound(4);
                TimeManager.instance.CurrentTimeCount += TimeManager.instance.CurrentTimePerSecond * 15;
                TimeManager.instance.TimeMultipler *= 1.05;
            }
        }
    }

}
