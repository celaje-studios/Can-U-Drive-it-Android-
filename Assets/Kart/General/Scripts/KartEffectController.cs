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
    GroundController ground;

    RaycastHit rightHit;
    string rHitName;
    RaycastHit leftHit;
    string lHitName;
    Ray rWheelRay;
    Ray lWheelRay;

    void Start()
    {
        isDrifting = false;
        rWheelRay = new Ray(rightWheelEffect.transform.position, -Vector3.up);
        lWheelRay = new Ray(leftWheelEffect.transform.position, -Vector3.up);
        rHitName = "";
        lHitName = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDrifting)
            return;
        
        
        if(Physics.Raycast(rWheelRay, out rightHit)){
            if(rightHit.transform.name != rHitName){
                ground = rightHit.transform.GetComponent<GroundController>();
                
            }
        }
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
