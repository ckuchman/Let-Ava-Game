using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    private Player _player;
    private GameState _gameState;
    public Text healthText;
    public Text coinText;

    void Start() {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _gameState = GameObject.Find("GameState").GetComponent<GameState>();
        healthText.text = _player.health.ToString();
        coinText.text = ((int)_gameState.coinScore).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = _player.health.ToString();
        coinText.text = ((int)_gameState.coinScore).ToString();
    }
}
