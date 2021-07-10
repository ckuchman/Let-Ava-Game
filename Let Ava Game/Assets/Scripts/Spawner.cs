using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstacle_ground;
    public GameObject obstacle_air;

    private float timeBtwSpawn;
    public float minTimeBtwSpawn;
    public float maxTimeBtwSpawn;

    // Update is called once per frame
    void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            if (Random.value < 0.3) 
            {
                float rand_height = Random.Range(3, 6);
                Instantiate(obstacle_air, new Vector3(transform.position.x, transform.position.y + rand_height, transform.position.x), Quaternion.identity);
            }
            else
            {
                Instantiate(obstacle_ground, transform.position, Quaternion.identity);
            }
            
            // Randomly set the time for the next obstacle
            timeBtwSpawn = Random.Range(minTimeBtwSpawn, maxTimeBtwSpawn);
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
