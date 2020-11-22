using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;
using Cinemachine;

public class Kart_SantoriniController : MonoBehaviour, IKartLevel
{
    [Header("Public References")]
    public CanvasGroup initUI;
    public CanvasGroup inGameUI;
    public CanvasGroup finishUI;
    public TextMeshProUGUI timerTxt;
    public KartSelectedSO kartSelected;
    public Transform kartSpawn;
    public CinemachineVirtualCamera Gamevcam;
    public CinemachineVirtualCamera Finishvcam;
    public TextMeshProUGUI velTxt;
    public TextMeshProUGUI auxTxt;

    //Variables Privadas
    enum States{_init, _inGame, _finish};
    States state;
    float raceTime;
    GameObject kart;
    CarroController kartControl;
    float money;

    public void StartRace(){
        initUI.DOFade(0f, .5f);
        inGameUI.DOFade(1f, .5f);
        state = States._inGame;
        kartControl.StartRace();
    }

    public void FinishRace(){
        state = States._finish;
        kartControl.FinishRace();
        inGameUI.DOFade(0f, .5f);
        activateFinishUI();
        SaveRaceResults();
    }

    public void SaveRaceResults(){
        Debug.Log("Tu timepo es: " +  Mathf.RoundToInt(raceTime/60) + "min" + Mathf.RoundToInt(raceTime%60) + "seg");
    }

    public void RestartLevel(){
        SceneManager.LoadScene("GreciaScene");
    }

    public void CalculateTime(){
        int min = Mathf.RoundToInt(raceTime / 60);
        int sec = Mathf.RoundToInt(raceTime % 60);
        timerTxt.text = "Race Time:  " + min + "min " + sec + "sec";
    }

    public void BackToSelectKart(){
        SceneManager.LoadScene("KartSelection");
    }

    void activateFinishUI(){
        CalculateTime();
        finishUI.DOFade(1f, .5f);
        finishUI.interactable = true;
        finishUI.blocksRaycasts = true;
    }

    void desactivateFinishUI(){
        finishUI.alpha = 0;
        finishUI.interactable = false;
        finishUI.blocksRaycasts = false;
    }

    void setCamera(){
        Gamevcam.Follow = kart.transform.GetChild(1);
        Gamevcam.LookAt = kart.transform.GetChild(1).GetChild(0);
    }

    void Start(){
        kart = Instantiate(kartSelected.kart, kartSpawn.position, kartSpawn.rotation);
        Debug.Log(kart.transform.name);
        kartControl = kart.GetComponentInChildren<CarroController>();
        kartControl.setTxtReferences(velTxt, auxTxt);
        state = States._init;
        initUI.alpha = 1f;
        setCamera();
        desactivateFinishUI();
    }

    void Update(){
        if(state == States._init){
            if(Input.touchCount > 0){
                StartRace();
            }
        }
        if(state == States._inGame){
            raceTime += Time.deltaTime;
        }
    }

    public void addMoney(float add){
        money += add;
    }
}
