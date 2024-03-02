using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
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
        print(sp.sprite);
        print(sprites[i]);
        print(i);
    }

}
