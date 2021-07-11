using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{    
    private GameObject _floor;
    private Player _player;
    private float _speed = 0;
    Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D> ();
        _player = GameObject.Find("Player").GetComponent<Player>();
        _floor = GameObject.Find("Right Road");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.angularVelocity = -(_player.maxProjectileSpeed - _speed);
        rb.velocity = transform.right * 10;

        if (transform.position.x > 24 || transform.position.y < 2) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        Destroy(gameObject);
    }

    public void setSpeed(float speed) {
        _speed = speed;
    }
}
