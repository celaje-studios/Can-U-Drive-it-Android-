using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class TouchController : MonoBehaviour
{

    //Variables Privadas
    Vector2 touchIniPos;
    Vector2 touchEndPos;

    void Start()
    {
        
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
                float fuerzaX = touchEndPos.x - touchIniPos.x;
                float fuerzaY = touchEndPos.y - touchIniPos.y;
                Debug.Log("move fuerza X: " + fuerzaX);
                Debug.Log("move fuerza Y: " + fuerzaY);
            }

            if(touch.phase == TouchPhase.Stationary){
                touchEndPos = touch.position;
                float fuerzaX = touchEndPos.x - touchIniPos.x;
                float fuerzaY = touchEndPos.y - touchIniPos.y;
                Debug.Log("stat fuerza X: " + fuerzaX);
                Debug.Log("stat fuerza Y: " + fuerzaY);
            }

            if(touch.phase == TouchPhase.Ended){
                touchEndPos = touch.position;
                Debug.Log("Ini: " +  touchIniPos);
                Debug.Log("Fin: " + touchEndPos);
            }

        }
    }
}
