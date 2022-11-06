using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float jumpForce;
    public int maxJumpCount;
    public bool isMoving = false;

    [Header("Dash")]
    public bool canDash = true;
    public bool isDashing;
    public float dashingPower = 16f;
    public float dashingTime = 0.12f;
    public float dashingCooldown = 1f;
    public int dashCount;
    [SerializeField] private TrailRenderer tr;

    [Header("Bounds Check")]
    public Transform ceilingCheck;
    public Transform groundCheck;
    public LayerMask groundObjects;

    private Rigidbody2D rb;
    public bool facingRight = true;
    private bool isJumping = false;
    private int jumpCount;
    private float maxYvelocity;

    // Player Movement
    public PlayerInput playerControls;

    Vector2 moveDirection = Vector2.zero;

    private InputAction move;
    private InputAction fire;

    [Header("Scripts")]
    // Player Animations
    public Animator animator;

    //Health Scripts
    public PlayerHealth playerhealth;

    //Player Collision Script
    public PlayerCollision playercollision;

    public GroundCheck groundcheck;

    [Header("Scene/Menu Scripts")]

    public PauseMenuScript pausemenuscript;

    public DeathSceneScript deathscenescript;

    public Transform playerspawn;



    private void Start()
    {
        
    }

    // Awake is called after all objects are initialized. Called in a random order
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerControls = new PlayerInput();
        jumpCount = maxJumpCount;
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();
    }

    private void OnDisble()
    {
        move.Disable();
    }

    // Update is called once per frame
    void Update()
    {

        if (isDashing)
        {
            return;
        }

        ProcessInputs();

        AnimateFlip();

        SmallerJump();

        Move();
        
    }

    //better for handling physics. can be called multiple times per update.
    private void FixedUpdate()
    {
        //check if on ground
        if(IsGrounded())
        {
            jumpCount = maxJumpCount;
            if(maxYvelocity <= -9) //if maximum y velocity is above certain threshold
            {
                TakeFallDamage(); //take fall damage
            }
        }
    }

    private void ProcessInputs()
    {
        moveDirection = move.ReadValue<Vector2>();

         if(Input.GetButtonDown("Jump") && jumpCount >= 1)
         {
            isJumping = true;
            maxYvelocity = 0;
         }
    }

    private void Move()
    {
        //horizontal movement
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
        if(rb.velocity.x == 0 && !pausemenuscript.isPaused && !deathscenescript.isDead)
        {
            animator.SetFloat("Speed", 0); //idle animation
            isMoving = false;
        }

        else if(rb.velocity.x != 0 && !pausemenuscript.isPaused && !playercollision.againstWall)
        {
            animator.SetFloat("Speed", 1); //run animation
            isMoving = true;
        }

        //jumping
        if(isJumping)
        {
            groundcheck.isGrounded = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
        }
        isJumping = false;

        if(rb.velocity.y < maxYvelocity) //if negative vertical velocity is increasing
        {
            maxYvelocity = rb.velocity.y; //new greatest negative vertical velocity
        }

        if(Input.GetButtonDown("Dash") && canDash)
        {
            StartCoroutine(Dash());
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            transform.position = playerspawn.position;
        }
    }

    private void AnimateFlip()
    {
        if (moveDirection.x > 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if (moveDirection.x < 0 && facingRight)
        {
            FlipCharacter();
        }
    }

    private void FlipCharacter()
    {
        if(!pausemenuscript.isPaused && !deathscenescript.isDead)
        {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
        }
    }

    private void SmallerJump()
    {
         if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private bool IsGrounded()
    {
        return groundcheck.isGrounded;
    }

    private void TakeFallDamage()
    {
        playerhealth.TakeDamage(5);
        maxYvelocity = 0; //reset maximum y velocity for next jump
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        Physics2D.IgnoreLayerCollision(10, 11, true);

        maxYvelocity = 0;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;

        if (facingRight)
        {
            rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        }
        else if (!facingRight)
        {
            rb.velocity = new Vector2(transform.localScale.x * -dashingPower, 0f);
        }
        tr.emitting = true;
        animator.SetBool("IsDashing", true);

        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;

        rb.gravityScale = originalGravity;
        isDashing = false;
        Physics2D.IgnoreLayerCollision(10, 11, false);
        animator.SetBool("IsDashing", false);
        
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
