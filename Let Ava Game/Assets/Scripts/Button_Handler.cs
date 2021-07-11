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
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Main");
        GameObject.Find("MainGameBGM").SetActive(true);
        GameObject.Find("GameOverBGM").SetActive(false);
    }  

    public void tutorial() {
        SceneManager.LoadScene("Tutorial");
    }
}
