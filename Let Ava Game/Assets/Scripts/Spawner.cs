using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstacle_ground;
    public GameObject obstacle_ground2;
    public GameObject obstacle_air;
    public GameObject obstacle_air2;

    private float _timeBtwSpawn;
    public float minTimeBtwSpawn;
    public float maxTimeBtwSpawn;
    private Vector3 _startPosition;
    public int minAirHeight, maxAirHeight;


    void Start () {
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update() {
        if (_timeBtwSpawn <= 0) {

            GameObject obst;
            
            if (Random.value < 0.3) {
                float rand_height = Random.Range(minAirHeight, maxAirHeight);

                if (Random.value < 0.5) {
                    obst = obstacle_air;
                } else {
                    obst = obstacle_air2;
                }
                
                Instantiate(obst, _startPosition + new Vector3(0.0f, rand_height, 0.0f), Quaternion.identity);
                
            } else {
                if (Random.value < 0.5) {
                    obst = obstacle_ground;
                } else {
                    obst = obstacle_ground2;
                }

                Instantiate(obst, transform.position, Quaternion.identity);
            }
            
            // Randomly set the time for the next obstacle
            _timeBtwSpawn = Random.Range(minTimeBtwSpawn, maxTimeBtwSpawn);
        } else {
            _timeBtwSpawn -= Time.deltaTime;
        }
    }
}
