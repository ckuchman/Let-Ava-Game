using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paperplane : MonoBehaviour
{
    public int damage = 1;
    public float init_speed_up, init_speed_left;

    void Update()
    {
        var target = GameObject.FindWithTag("Player").transform;
        
        transform.Translate(Vector2.left * init_speed_left * Time.deltaTime);

        if (target.position.y > transform.position.y)
        {
            transform.Translate(Vector2.up * init_speed_up * Time.deltaTime);
        } 
        else
        {
            transform.Translate(Vector2.up * -init_speed_up * Time.deltaTime);
        }

        if (transform.position.x < -12)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            //other.GetComponent<Player>().health -= damage;
            Destroy(gameObject);
        }
    }
}
