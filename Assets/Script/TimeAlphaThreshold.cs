using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeAlphaThreshold : MonoBehaviour
{
    private Image _TachyonImage;
    private void Awake()
    {
        _TachyonImage = GetComponent<Image>();
        _TachyonImage.alphaHitTestMinimumThreshold = 0.001f;
    }

}
