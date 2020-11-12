using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kart_SantoriniController : MonoBehaviour, IKartLevel
{
    [Header("Public References")]
    public CanvasGroup initUI;
    public CanvasGroup inGameUI;
    public CanvasGroup finishUI;

    //Variables Privadas
    enum States{_init, _inGame, _finish};
    States state;
    public float raceTime;

    public void StartRace(){
        state = States._inGame;
    }

    public void FinishRace(){
        state = States._finish;
        SaveRaceResults();
    }

    public void SaveRaceResults(){
        Debug.Log("Tu timepo es: " +  Mathf.RoundToInt(raceTime/60) + "min" + Mathf.RoundToInt(raceTime%60) + "seg");
    }

    void Start(){
        state = States._init;
    }

    void Update(){
        if(state == States._init){
            if(Input.touchCount > 0){
                initUI.alpha = 0;
            }
        }
        if(state == States._inGame){
            raceTime += Time.deltaTime;
        }
    }
}
