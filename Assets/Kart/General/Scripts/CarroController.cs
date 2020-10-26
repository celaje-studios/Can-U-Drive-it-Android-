using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarroController : MonoBehaviour
{

    [Header("Public References")]
    public Rigidbody rigidbody;
    public Transform kartModel;
    public KartEffectController kartEffect;

    [Header("Parameters")]
    public float forwardForce = 70f;
    public float steering = 20;

    //Variables Privadas
    Vector2 touchIniPos;
    Vector2 touchEndPos;
    float distanciaX;
    float distanciaY;
    float rotate, currentRotate;
    float currentForce;
    float maxAcceleration, maxBreak;

    void Start()
    {
        maxAcceleration = forwardForce*.4f;
    }


    void Update()
    {

        if(Input.touchCount > 0){

            Touch touch = Input.GetTouch(0);
            
            if(touch.phase == TouchPhase.Began){
                touchIniPos = touch.position;
            }

            if(touch.phase == TouchPhase.Moved){
                touchEndPos = touch.position;
                distanciaX = Mathf.Clamp(touchEndPos.x - touchIniPos.x, -200, 200) / 200;
                Steer(distanciaX);
                distanciaY = maxAcceleration * Mathf.Clamp(touchEndPos.y - touchIniPos.y, -100, 100) / 100;

            }

            if(touch.phase == TouchPhase.Stationary){
                touchEndPos = touch.position;
                distanciaX = Mathf.Clamp(touchEndPos.x - touchIniPos.x, -200, 200) / 200;
                Steer(distanciaX);
                distanciaY = maxAcceleration * Mathf.Clamp(touchEndPos.y - touchIniPos.y, -100, 100) / 100;
            }

            if(touch.phase == TouchPhase.Ended){
                touchEndPos = touch.position;

                kartEffect.stopDrifting();

            }

            currentForce = forwardForce + distanciaY;

        }else{
            rotate = 0f;
            currentForce = forwardForce;
        }

        currentRotate = Mathf.Lerp(currentRotate, rotate, Time.deltaTime * 4f);

        Vector3 newKartPos = Vector3.Lerp(transform.position,rigidbody.transform.position, Time.deltaTime * 1.5f);
        newKartPos = new Vector3 (newKartPos.x, transform.position.y, newKartPos.z);
        transform.position = newKartPos;


    }

    void FixedUpdate(){
        rigidbody.AddForce(transform.forward * currentForce, ForceMode.Acceleration);

        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, transform.eulerAngles.y + currentRotate, 0), Time.deltaTime * 5f);
        kartModel.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, transform.eulerAngles.y + currentRotate*2f, 0), Time.deltaTime * 5f);
    }

    public void Steer(float amount)
    {
        rotate = steering * amount;

        if(Mathf.Abs(amount) > .5f){
            kartEffect.startDrifting();
        }else{
            kartEffect.stopDrifting();
        }
    }
}
