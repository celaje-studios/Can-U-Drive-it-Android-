using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoReturnMenu : MonoBehaviour
{
    public void LoadMainMenu(){
         SceneManager.LoadScene("DemoMainMenu");
    }
}
