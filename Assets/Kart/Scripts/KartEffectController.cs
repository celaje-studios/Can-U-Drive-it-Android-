using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartEffectController : MonoBehaviour
{

    [Header("Public References")]
    public ParticleSystem rightWheelEffect;
    public ParticleSystem leftWheelEffect;

    //Variables Privadas
    bool isDrifting;

    RaycastHit hit;
    Ray ray;
    enum grounds{_calle, _grama, _tierra};

    void Start()
    {
        isDrifting = false;
        ray = new Ray(transform.position, -Vector3.up);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startDrifting(){
        Debug.Log("drifting");
        if(!rightWheelEffect.isEmitting){
            rightWheelEffect.Play();
            leftWheelEffect.Play();
        }
    }

    public void stopDrifting(){
        rightWheelEffect.Stop();
        leftWheelEffect.Stop();
    }
}
