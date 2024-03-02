using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class rotationAiguilles : MonoBehaviour
{
    [SerializeField] private Image minutes;
    [SerializeField] private Image heures;

    public void ClickHorloge()
    {
        minutes.rectTransform.Rotate(Vector3.forward, -6);
        heures.rectTransform.Rotate(Vector3.forward, (float)-0.5);
        Debug.Log("AAAA");
    }
}
