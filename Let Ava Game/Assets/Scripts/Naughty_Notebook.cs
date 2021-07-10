using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Naughty_Notebook : MonoBehaviour
{
    public GameObject paperplane;

    private float timeTillSpawn;
    public float startTimeTillSpawn;
    public float timeBtwSpawn;
    public float startSpeed;
    private bool hasPaused = false;
    public float pauseTime;
    public float pauseTimeTillRunBack;
    public float runBackXPos;
    public float runBackSpeed;
    private float speed;

    void Start()
    {
        timeTillSpawn = startTimeTillSpawn;
        speed = startSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        //When it hits a certain closeness, it first pauses then runs away
        if (transform.position.x < runBackXPos)
        {
            speed = runBackSpeed;
        }
        
        // Spawns paperplanes
        if (timeTillSpawn <= 0)
        {
            Instantiate(paperplane, transform.position, Quaternion.identity);
            
            timeTillSpawn = timeBtwSpawn;
        }
        else
        {
            timeTillSpawn -= Time.deltaTime;
        }
    }
}
