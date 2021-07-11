using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class Button_Handler : MonoBehaviour
{    
    public void exitGame() {
        Application.Quit();
    }

    public void startGame() {
        SceneManager.LoadScene("Main");
        Time.timeScale = 1;
    }  

    public void tutorial() {
        SceneManager.LoadScene("Tutorial");
    }
}
