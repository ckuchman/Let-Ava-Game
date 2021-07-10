using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstacle_ground;
    public GameObject obstacle_air;

    private float _timeBtwSpawn;
    public float minTimeBtwSpawn;
    public float maxTimeBtwSpawn;
    private Vector3 _startPosition;


    void Start () {
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update() {
        if (_timeBtwSpawn <= 0) {
            if (Random.value < 0.3) {
                float rand_height = Random.Range(3, 6);
                Instantiate(obstacle_air, _startPosition + new Vector3(0.0f, rand_height, 0.0f), Quaternion.identity);
            } else {
                Instantiate(obstacle_ground, transform.position, Quaternion.identity);
            }
            
            // Randomly set the time for the next obstacle
            _timeBtwSpawn = Random.Range(minTimeBtwSpawn, maxTimeBtwSpawn);
        } else {
            _timeBtwSpawn -= Time.deltaTime;
        }
    }
}
