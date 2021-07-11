using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public float coinScore = 0;
    public float distance = 0;
    public float time = 0;
    
    void Update()
    {;
        distance += 1.5f * Time.deltaTime;
        time += 1.0f * Time.deltaTime;
    }
}
