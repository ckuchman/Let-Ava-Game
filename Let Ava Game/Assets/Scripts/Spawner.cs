using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstacle_ground;
    public GameObject obstacle_ground2;
    public GameObject obstacle_ground3;    
    public GameObject obstacle_air;
    public GameObject obstacle_air2;
    public GameObject heart;
    public GameObject coin;

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

            float rand1 = Random.value;
            float rand2 = Random.value;
            // Handle pickups
            if (rand1 < 0.6) {
                float rand_height = Random.Range(1, maxAirHeight);
                
                if (rand2 < 0.95) {
                    obst = coin;
                } else {
                    obst = heart;
                }

                Instantiate(obst, _startPosition + new Vector3(0.0f, rand_height, 0.0f), Quaternion.identity);

            // Handle Flying Obstacles
            } else if (rand1 < 0.7) {
                
                float rand_height = Random.Range(minAirHeight, maxAirHeight);

                if (rand2 < 0.5) {
                    obst = obstacle_air;
                } else {
                    obst = obstacle_air2;
                }
                
                Instantiate(obst, _startPosition + new Vector3(0.0f, rand_height, 0.0f), Quaternion.identity);
            
            // Handle Ground obstacles (most common)    
            } else {
                if (rand2 < 0.5) {
                    obst = obstacle_ground;
                } else if (rand2 < 0.9) {
                    obst = obstacle_ground2;
                }
                else {
                    obst = obstacle_ground3;
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
