using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public Text healthText;
    public Text coinText;
    public float coinScore = 0;
    private Player _player;

    void Start() {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        healthText.text = _player.health.ToString();
        coinText.text = ((int)coinScore).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = _player.health.ToString();
        coinText.text = ((int)coinScore).ToString();

        coinScore += 1.0f * Time.deltaTime;
    }
}
