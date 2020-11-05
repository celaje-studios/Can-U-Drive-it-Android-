using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartEffectController : MonoBehaviour
{

    [Header("Public References")]
    public ParticleSystem smokeParticles;
    public ParticleSystem groundParticles;
    public CarroController kart;
    public Material smokeMat;
    public Transform wheekFR;
    public Transform wheekFL;
    public Transform steerWheelFR;
    public Transform steerWheelFL;
    public Transform wheelBR;
    public Transform wheelBL;

    [Header("Parameters")]
    public float rotationSpeed = 5f;
    public Vector3 driftRotation;
    public Color streetColor;
    public Color grassColor;
    public Color nieveColor;
    public Color TierraColor;
    public Color PiedraColor;

    //Variables Privadas
    bool isDrifting;

    void Start()
    {
        isDrifting = false;
    }

    void Update(){
        wheekFL.Rotate(Vector3.right , Time.deltaTime*rotationSpeed);
        wheekFR.Rotate(Vector3.right , Time.deltaTime*rotationSpeed);
        wheelBL.Rotate(Vector3.right , Time.deltaTime*rotationSpeed);
        wheelBR.Rotate(Vector3.right , Time.deltaTime*rotationSpeed);
    }

    public void startDrifting(float amount){
            Quaternion rot = Quaternion.Euler(driftRotation * amount);
            steerWheelFL.localRotation = rot;
            steerWheelFR.localRotation = rot;

        if(Mathf.Abs(amount) > .5f){
            if(!smokeParticles.isEmitting){
                smokeParticles.Play();
            }
        }else{
            smokeParticles.Stop();
        }
    }

    public void stopDrifting(){
        Quaternion rot = Quaternion.Euler(Vector3.zero);
        steerWheelFL.localRotation = rot;
        steerWheelFR.localRotation = rot;
        smokeParticles.Stop();
    }

    void OnCollisionEnter(Collision col)
    {
    if(col.transform.tag == "street"){
            kart.isOnStreet(true);    
            smokeMat.color = streetColor;        
    }else if(col.transform.tag == "grass"){
        kart.isOnStreet(false);
        smokeMat.color = grassColor;
    }else if(col.transform.tag == "Piedra"){
        kart.isOnStreet(false);
        smokeMat.color = PiedraColor;

    }
    }

    void OnCollisionExit(Collision col)
    {
        if(col.transform.tag == "utilery"){
            kart.leaveColition();
        }else if(col.transform.tag == "limits"){
            kart.leaveColition();
        }
    }
}
