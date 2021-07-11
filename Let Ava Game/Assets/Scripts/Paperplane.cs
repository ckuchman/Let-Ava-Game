using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paperplane : MonoBehaviour
{
    public int damage = 1;
    public float speed = 9;
    public float rotatingSpeed = 200;
    private bool _passedPlayer = false;
    private GameObject _target;
    Rigidbody2D rb;

    void Start() {
        _target = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D> ();
    }
 
    void FixedUpdate() {
        // Check if it is passed the player
        if (transform.position.x < _target.transform.position.x) {
            _passedPlayer = true;
        }

        // Tracks the player until it passed by the player
        if (!_passedPlayer) {
            Vector2 point2Target = (Vector2)transform.position - (Vector2)_target.transform.position;
            point2Target.Normalize();

            float cross = Vector3.Cross(point2Target, transform.right).z;

            if (cross < 0) {
                rb.angularVelocity = rotatingSpeed;
            } else if (cross > 0) {
                rb.angularVelocity = -rotatingSpeed;
            } else {
                rb.angularVelocity = 0;
                //rotatingSpeed = 0;
            }
        } else {
            rb.angularVelocity = 0;
        }

        rb.velocity = -transform.right * speed;

        if (transform.position.x < -24) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        //Disappears when hits the player
        if (other.CompareTag("Player")) {
            other.GetComponent<Player>().health -= damage;
            Destroy(gameObject);
        }

        //Is is destroyed by projectiles
        if (other.CompareTag("Projectile")) {
            Destroy(gameObject);
        }
    }
}
