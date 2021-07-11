using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public float speed;
    private SFXPlayer _SFXPlayer;

    void Start() {
        _SFXPlayer = GameObject.Find("SFXPlayer").GetComponent<SFXPlayer>();
    }

    void Update() {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < -24)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        //Disappears when hits the player
        if (other.CompareTag("Player")) {
            other.GetComponent<Player>().health += 1;
            _SFXPlayer.playHeartCollect();
            Destroy(gameObject);
        }

        //Is is destroyed by projectiles
        if (other.CompareTag("Projectile")) {
            _SFXPlayer.playCollectDestroy();
            Destroy(gameObject);
        }
    }
}
