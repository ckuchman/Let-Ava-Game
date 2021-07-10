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
    private bool jumped;
    // Start is called before the first frame update
    void Start()
    {
        jumped = false;
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
        if (isGrounded == true) {
            extraJumps = extraJumpValue;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0) {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
            CreateDust();
        } else if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true) {
            rb.velocity = Vector2.up * jumpForce;
            CreateDust();
        }
    }

    void CreateDust() {
        dust.Play();
    }
}
