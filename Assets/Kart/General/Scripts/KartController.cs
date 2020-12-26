using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartController : MonoBehaviour
{
    [Header("Public References")]
    public Rigidbody sphere;
    public Transform kartModel;

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

    enum States{_init, _inGame, _finish};
    States state;

    // Start is called before the first frame update
    void Start()
    {
        state = States._init;
        maxAcceleration = forwardForce*.4f;
        currentForce = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!(state == States._inGame))
            Debug.Log("init state");
            //return;

        if(Input.touchCount > 0){
            Debug.Log("toque");
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
            }

                currentForce = forwardForce + distanciaY;

            }else{
                currentForce = forwardForce;
            }

        currentRotate = Mathf.Lerp(currentRotate, rotate, Time.deltaTime * 4f);

        transform.position = Vector3.Lerp(transform.position, sphere.transform.position, Time.deltaTime * 5f);
    }

    void FixedUpdate(){

        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, transform.eulerAngles.y + currentRotate, 0), Time.deltaTime * 5f);
        kartModel.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, transform.eulerAngles.y + currentRotate*2f, 0), Time.deltaTime * 5f);
        
        sphere.AddForce(transform.forward * currentForce, ForceMode.Acceleration);

    }

    public void Steer(float amount)
    {
        rotate = steering * amount;

    }
}
