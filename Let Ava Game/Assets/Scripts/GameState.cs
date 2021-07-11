using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public float coinScore = 0;
    public float distance = 0;
    
    void Update()
    {
        coinScore += 1.0f * Time.deltaTime;
        distance += 1.5f * Time.deltaTime;
    }
}
