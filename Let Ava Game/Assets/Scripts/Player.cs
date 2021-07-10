using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float moveInput;
    private Rigidbody2D rb;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private int extraJumps;
    public int extraJumpValue;
    public ParticleSystem dust;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Update() {
        resetJumps();
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            if (extraJumps > 0) {
                Jump(1);
            } else if (extraJumps == 0 && isGrounded == true) {
                Jump(0);
            }
        } else if (Input.GetKeyDown(KeyCode.Space)) {
            Attack();
        }
    }

    void CreateDust() {
        dust.Play();
    }

    void Jump(int jumps) { 
        rb.velocity = Vector2.up * jumpForce;
        extraJumps = extraJumps - jumps;
        CreateDust();
    }

    void resetJumps() {
        if (isGrounded == true) {
            extraJumps = extraJumpValue;
        }
    }

    void Attack() {
        // Play an attack animation
        animator.SetTrigger("Shoot");
        // Detect enemies in range of attack
        // Destroy the enemy
    }
}
