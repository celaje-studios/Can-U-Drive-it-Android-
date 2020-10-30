using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarroController : MonoBehaviour
{

    [Header("Public References")]
    public Rigidbody sphere;
    public Transform kartModel;
    public KartEffectController kartEffect;

    [Header("Parameters")]
    public float forwardForce = 70f;
    public float steering = 20;

    /*********************
    * Variables Privadas
    *********************/
    Vector2 touchIniPos, touchEndPos;
    float distanciaX, distanciaY;
    float rotate, currentRotate;
    float currentForce, maxAcceleration;
    bool reposition, breaking;

    void Start()
    {
        maxAcceleration = forwardForce*.4f;
        reposition = false;
    }


    void Update()
    {
        if(!reposition){
            if(Input.touchCount > 0){

                Touch touch = Input.GetTouch(0);
                
                if(touch.phase == TouchPhase.Began){
                    touchIniPos = touch.position;
                }

                if(touch.phase == TouchPhase.Moved){
                    touchEndPos = touch.position;
                    distanciaX = Mathf.Clamp(touchEndPos.x - touchIniPos.x, -150, 150) / 150;
                    distanciaY = maxAcceleration * Mathf.Clamp(touchEndPos.y - touchIniPos.y, -75, 75) / 75;
                    Steer(distanciaX);
                }

                if(touch.phase == TouchPhase.Stationary){
                    Steer(distanciaX);
                }

                if(touch.phase == TouchPhase.Ended){
                    rotate = 0f;
                    currentForce = forwardForce;
                    kartEffect.stopDrifting();
                }

                currentForce = forwardForce + distanciaY;

            }

            currentRotate = Mathf.Lerp(currentRotate, rotate, Time.deltaTime * 4f);

            transform.position = Vector3.Lerp(transform.position, sphere.transform.position, Time.deltaTime * 5f);
        }
    }

    void FixedUpdate(){
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, transform.eulerAngles.y + currentRotate, 0), Time.deltaTime * 5f);
        kartModel.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, transform.eulerAngles.y + currentRotate*2f, 0), Time.deltaTime * 5f);
        
        if(breaking){
            sphere.AddForce(transform.forward * currentForce, ForceMode.Acceleration);
        }else{
            sphere.AddForce(transform.forward * currentForce * .5f, ForceMode.Acceleration);
        }
        
    }

    public void Steer(float amount)
    {
        rotate = steering * amount;

        kartEffect.startDrifting(amount);

    }

    public void leaveColition(){
        Debug.Log("reposition");
        reposition = true;
        currentForce = 0;
        sphere.position = new Vector3(kartModel.position.x, sphere.position.y, kartModel.position.z);
        transform.position = new Vector3(kartModel.position.x, transform.position.y, kartModel.position.z);
        kartModel.localPosition = new Vector3(0,kartModel.localPosition.y, 0);
        reposition = false;
    }

    public void isOnStreet(bool inbreak){
        breaking = inbreak;
    }

    public void isOnColition(bool colition){

    }
}
