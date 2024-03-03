using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI; 

public class objets_animés : MonoBehaviour
{
    public Sprite Objet;
    public int i = 0;
    public Texture2D text;
    public Image sp;
    public Sprite[] sprites;

    public void Start()
    {
        sp = GetComponent<Image>();   
        sprites = Resources.LoadAll<Sprite>(text.name);
        sp.sprite = sprites[0];


        
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
        if (i % 6 == 0 && sprites.Length == 6)
        {
            TimeManager.instance.CurrentTimeCount += TimeManager.instance.CurrentTimePerSecond * 2;
            TimeManager.instance.TimeMultipler *= 1.005;
        }
        if (i % 18 == 0 && sprites.Length == 18)
        {
            TimeManager.instance.CurrentTimeCount += TimeManager.instance.CurrentTimePerSecond * 6;
            TimeManager.instance.TimeMultipler *= 1.01;
        }
        if (i % 35 == 0 && sprites.Length == 35)
        {
            TimeManager.instance.CurrentTimeCount += TimeManager.instance.CurrentTimePerSecond * 15;
            TimeManager.instance.TimeMultipler *= 1.02;
        }
        if (i % 11 == 0 && sprites.Length == 11)
        {
            TimeManager.instance.CurrentTimeCount += TimeManager.instance.CurrentTimePerSecond * 15;
            TimeManager.instance.TimeMultipler *= 1.05;
        }
    }

}
