using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartEffectController : MonoBehaviour
{

    [Header("Public References")]
    public ParticleSystem rightWheelEffect;
    public ParticleSystem leftWheelEffect;
    public ParticleSystem groundParticles;

    //Variables Privadas
    bool isDrifting;


    void Start()
    {
        isDrifting = false;

    }


    public void startDrifting(){
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
