using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Naughty_Notebook : MonoBehaviour
{
    public GameObject paperplane;

    private float timeTillSpawn;
    public float timeBtwSpawn;

    // Update is called once per frame
    void Update()
    {
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
