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
    public Animator animator;
    public ProjectileBehavior projectile;
    public Transform launchOffset;
    public int health;
    private SFXPlayer _SFXPlayer;
    public float maxProjectileSpeed;
    public float projectileChargeRate;
    public float currentShotCharge;
    public float shootRate;
    private float _timeTillShoot = 0;

    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
        _SFXPlayer = GameObject.Find("SFXPlayer").GetComponent<SFXPlayer>();
        currentShotCharge = maxProjectileSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
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
            Shoot();
        }

        // Handle the slow charge of the gun
        if (currentShotCharge < maxProjectileSpeed) {
            currentShotCharge += projectileChargeRate * Time.deltaTime;

            if (currentShotCharge > maxProjectileSpeed) {
                currentShotCharge = maxProjectileSpeed;
            }
        }

        // Handle shoot rate limiting
        if (_timeTillShoot > 0) {
            _timeTillShoot -= 1 * Time.deltaTime;
        }
    }

    void CreateDust() {
        dust.Play();
    }

    void Jump(int jumps) { 
        rb.velocity = Vector2.up * jumpForce;
        extraJumps = extraJumps - jumps;
        CreateDust();
        _SFXPlayer.playPlayerJump();
    }

    void resetJumps() {
        if (isGrounded == true) {
            extraJumps = extraJumpValue;
        }
    }

    void Shoot() {
        if (_timeTillShoot <= 0) {
            ProjectileBehavior proj = Instantiate(projectile, launchOffset.position, transform.rotation);
            proj.setSpeed(currentShotCharge);
            _SFXPlayer.playPlayerShot();
            currentShotCharge = 0;
            _timeTillShoot = shootRate;
        }
    }
}
