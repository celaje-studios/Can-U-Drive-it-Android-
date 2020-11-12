using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaController : MonoBehaviour
{
    [Header("Public References")]
    [SerializeField, SerializeReference]
    public GameObject LevelControl;

    [Header("Parameters")]
    public bool isStart;

    void OnTriggerEnter(Collider col)
    {
        if(isStart){
            Debug.Log("Meta inicio atravesada");
            LevelControl.GetComponent<IKartLevel>().StartRace();
        }else{
            Debug.Log("MEta fin atravesada");
            LevelControl.GetComponent<IKartLevel>().FinishRace();
        }
    }

}
