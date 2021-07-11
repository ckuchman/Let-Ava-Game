using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Naughty_Notebook : MonoBehaviour
{
    public GameObject paperplane;
    public GameObject homework;
    public GameObject NNSpawner;    

    private float _timeTillSpawn;
    public float startTimeTillSpawn;
    public float minTimeBtwSpawn;
    public float maxTimeBtwSpawn;
    public float startSpeed;
    private bool _hasPaused = false;
    public float pauseTime;
    private float _pauseTimeTillRunBack = 0;
    public float runBackXPos;
    public float runBackSpeed;
    private float _speed;

    void Start() {
        _timeTillSpawn = startTimeTillSpawn;
        _speed = startSpeed;
    }

    // Update is called once per frame
    void Update() {
        // When it hits a certain closeness, it first pauses
        if (transform.position.x < runBackXPos && !_hasPaused) {
            _speed = 0;
            _hasPaused = true;
            _pauseTimeTillRunBack = pauseTime;
        }

        // It stays paused for set time
        if (_hasPaused && _pauseTimeTillRunBack >= 0) {
            _pauseTimeTillRunBack -= Time.deltaTime;
        }

        // After pausing it runs back
        if (_pauseTimeTillRunBack < 0) {
            _speed = runBackSpeed;
        }
        
        // Spawns projectiles
        if (_timeTillSpawn <= 0) {
            if (Random.value < 0.8) {
                Instantiate(paperplane, transform.position, Quaternion.Euler(0, 0, -35));
            } else {
                Instantiate(homework, transform.position, Quaternion.Euler(0, 0, -35));
            }

            _timeTillSpawn = Random.Range(minTimeBtwSpawn, maxTimeBtwSpawn);
        } else {
            _timeTillSpawn -= Time.deltaTime;
        }

        // Movement
        transform.Translate(Vector2.left * _speed * Time.deltaTime);


        // Vertical ossilation to make movement seem more natural
        float vertical = Mathf.Sin(Time.time * 2) * .0005f;
        transform.position = transform.position + new Vector3(0.0f, vertical, 0.0f);

        //Removes the NN when it passes behind the spawner
        if (transform.position.x > NNSpawner.transform.position.x) {
            Destroy(gameObject);
        }
    }
}
