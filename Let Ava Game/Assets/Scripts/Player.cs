using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private Rigidbody2D rb;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private int extraJumps;
    public int extraJumpValue;
    public ParticleSystem dust;
    private Animator animator;
    public ProjectileBehavior projectile;
    public Transform launchOffset;
    public int health;
    private int prevHealth;
    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpValue;
        prevHealth = health;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        animator.SetBool("gameOver", false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if (isGrounded == true) {
            animator.SetBool("isRunning", true);
        } else {
            animator.SetBool("isRunning", false);
        }
    }

    void Update() {
        if (prevHealth > health) { 
            animator.SetTrigger("tookDamage");
            if (health == 0) {
                animator.SetBool("gameOver", true);
            }
            prevHealth = health;
        }
        resetJumps();
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            if (extraJumps > 0) {
                Jump(1);
            } else if (extraJumps == 0 && isGrounded == true) {
                Jump(0);
            }
        } else if (Input.GetKeyDown(KeyCode.Space)) {
            Shoot();
        }
    }

    void CreateDust() {
        dust.Play();
    }

    void Jump(int jumps) { 
        animator.SetTrigger("takeOff");
        rb.velocity = Vector2.up * jumpForce;
        extraJumps = extraJumps - jumps;
        CreateDust();
    }

    void resetJumps() {
        if (isGrounded == true) {
            extraJumps = extraJumpValue;
        }
    }

    void Shoot() {
        // Play an attack animation
        // animator.SetTrigger("Shoot");
        Instantiate(projectile, launchOffset.position, transform.rotation);
        // Detect enemies in range of attack
        // Destroy the enemy
    }
}
