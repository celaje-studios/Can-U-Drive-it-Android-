﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarroController : MonoBehaviour
{
    [Header("Temporal References")]
    public TextMeshProUGUI speedTxt;
    public TextMeshProUGUI rotationTxt;

    [Header("Public References")]
    public Rigidbody rigidbody;

    public Transform kartModel;

    [Header("Parameters")]
    public float forwardForce = 5f;
    public float gravity = 10f;
    public float steering = 40f;

    //Variables Privadas
    Vector2 touchIniPos;
    Vector2 touchEndPos;
    float distanciaX;
    float distanciaY;
    float rotate, currentRotate;
    float currentForce;
    float maxAcceleration;

    void Start()
    {
        maxAcceleration = forwardForce*.3f;
    }


    void Update()
    {
            speedTxt.text = "Speed: " + currentForce;
            rotationTxt.text = "Rotation: " + currentRotate;

        if(Input.touchCount > 0){

            Touch touch = Input.GetTouch(0);
            
            if(touch.phase == TouchPhase.Began){
                touchIniPos = touch.position;
            }

            if(touch.phase == TouchPhase.Moved){
                touchEndPos = touch.position;
                distanciaX = Mathf.Clamp(touchEndPos.x - touchIniPos.x, -100, 100) / 100;
                int dir = distanciaX > 0 ? 1 : -1;
                Steer(dir, Mathf.Abs(distanciaX));
                distanciaY = maxAcceleration * Mathf.Clamp(touchEndPos.y - touchIniPos.y, -50f, 50f) / 50;

            }

            if(touch.phase == TouchPhase.Stationary){
                touchEndPos = touch.position;
                distanciaX = Mathf.Clamp(touchEndPos.x - touchIniPos.x, -100, 100) / 100;
                int dir = distanciaX > 0 ? 1 : -1;
                Steer(dir, Mathf.Abs(distanciaX));
                distanciaY = maxAcceleration * Mathf.Clamp(touchEndPos.y - touchIniPos.y, -50f, 50f) / 50;

            }

            if(touch.phase == TouchPhase.Ended){
                touchEndPos = touch.position;
                if(touchIniPos == touchEndPos){
                    Debug.Log("Tap");
                }

            }

            currentForce = forwardForce + distanciaY;

        }else{
            rotate = 0f;
            currentForce = forwardForce;
        }

        currentRotate = Mathf.Lerp(currentRotate, rotate, Time.deltaTime * 4f);
        transform.position = Vector3.Lerp(transform.position, rigidbody.transform.position - new Vector3(0, 0.8f, 0), Time.deltaTime * 1.5f);

    }

    void FixedUpdate(){
        rigidbody.AddForce(transform.forward * currentForce, ForceMode.Acceleration);

        rigidbody.AddForce(Vector3.down * gravity, ForceMode.Acceleration);

        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, transform.eulerAngles.y + currentRotate, 0), Time.deltaTime * 5f);
        kartModel.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, transform.eulerAngles.y + currentRotate*2f, 0), Time.deltaTime * 5f);
    }

    public void Steer(int direction, float amount)
    {
        rotate = (steering * direction) * amount;
    }
}