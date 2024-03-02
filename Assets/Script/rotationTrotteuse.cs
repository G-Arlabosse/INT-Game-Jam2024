using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class rotationTrotteuse : MonoBehaviour
{
    [SerializeField] private Image trotteuse;
    private int i = 0;

    public void ClickChrono()
    {
        trotteuse.rectTransform.Rotate(Vector3.forward, -6);
        i++;
        if (i % 60 == 0)
        {
            TimeManager.instance.CurrentTimeCount += 0;
        }
    }
}
