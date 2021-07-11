using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver_Menu : MonoBehaviour
{
    private Player _player;
    private GameState _gameState;
    public GameObject gameOverMenuUI;
    public GameObject MainGameBGM;
    public GameObject GameOverBGM;
    public Text distanceText;
    public Text coinText;
    public Text timeText;

    void Start() {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _gameState = GameObject.Find("GameState").GetComponent<GameState>();
        
        coinText.text = ((int)_gameState.coinScore).ToString();
        distanceText.text = ((int)_gameState.distance).ToString();
    }

    // Update is called once per frame
    void Update() {
        coinText.text = ((int)_gameState.coinScore).ToString();
        distanceText.text = ((int)_gameState.distance).ToString();
        
        if (_player.health <= 0) {
            MainGameBGM.SetActive(false);
            GameOverBGM.SetActive(true);
            gameOverMenuUI.SetActive(true);
            Time.timeScale = 0;
            _player.health = 5;
        }
    }
}
