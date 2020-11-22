using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class KartSelectionController : MonoBehaviour
{
    [Header("Public References")]
    public GameObject[] Karts;
    public CanvasGroup kartSelectionUI;
    public CanvasGroup stageSelectionUI;
    public KartSelectedSO kartSelection;

    //Variables Privadas
    enum States{_karts, _stage};
    States state;

    void Start()
    {
        state = States._karts;
    }

    public void kartSelected(){
        state = States._stage;
        ActivateKartUI(false);
        ActivateStageUI(true);
    }

    public void BackButton(){
        if(state == States._stage){
            state = States._karts;
            ActivateKartUI(true);
            ActivateStageUI(false);
        }else if(state == States._karts){
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void ActivateKartUI(bool act){
        if(act){
            kartSelectionUI.DOFade(1f, .5f);
            kartSelectionUI.interactable = true;
            kartSelectionUI.blocksRaycasts = true;
        }else{
            kartSelectionUI.DOFade(0f, .5f);
            kartSelectionUI.interactable = false;
            kartSelectionUI.blocksRaycasts = false;
        }
    }

    public void ActivateStageUI(bool act){
        if(act){
            stageSelectionUI.DOFade(1f, .5f);
            stageSelectionUI.interactable = true;
            stageSelectionUI.blocksRaycasts = true;
        }else{
            stageSelectionUI.DOFade(0f, .5f);
            stageSelectionUI.interactable = false;
            stageSelectionUI.blocksRaycasts = false;
        }
    }

    public void KartSlot1(){
        kartSelection.kart = Karts[0];
        kartSelected();
    }

    public void KartSlot2(){
        kartSelection.kart = Karts[1];
        kartSelected();
    }

    public void KartSlot3(){
        kartSelection.kart = Karts[2];
        kartSelected();
    }

    public void KartSlot4(){

    }

    public void KartSlot5(){

    }

    public void KartSlot6(){

    }

    public void StageSlot1(){
        SceneManager.LoadScene("GreciaScene");
    }

    public void StageSlot2(){

    }

    public void StageSlot3(){

    }

    public void StageSlot4(){

    }
}
