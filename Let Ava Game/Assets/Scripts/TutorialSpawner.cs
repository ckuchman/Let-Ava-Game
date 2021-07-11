using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSpawner : MonoBehaviour
{
    public GameObject obstacle;
    public float startTimeBtwObstacle;
    private float timeBtwObstacle;
    public int numOfObstacles;

    // Update is called once per frame
    void Update()
    {
        if (timeBtwObstacle <= 0 && numOfObstacles > 0) {
            Instantiate(obstacle, transform.position, Quaternion.identity);
            timeBtwObstacle = startTimeBtwObstacle;
            numOfObstacles--;
        } else {
            timeBtwObstacle -= Time.deltaTime;
        }
    }
}
