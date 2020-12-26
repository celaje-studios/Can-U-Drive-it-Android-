using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LimitController : MonoBehaviour
{
    [Header("Public Refernces")]
    public Material mat;

    public Color transColor;
    public Color DefColor;
    
    void Start () {
        mat.color = transColor;
	}

    void OnTriggerEnter(Collider col)
    {
        mat.DOColor(DefColor, 1f);
    }

    void OnTriggerExit(Collider other)
    {
        mat.DOColor(transColor, 1f);
    }

    void OnTriggerStay(Collider other)
    {
        mat.DOColor(DefColor, 1f);
    }

}
