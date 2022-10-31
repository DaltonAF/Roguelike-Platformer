using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float sprintSpeed;
    public float jumpForce;
    public int maxJumpCount;

    [Header("Misc")]
    public Transform ceilingCheck;
    public Transform groundCheck;
    public LayerMask groundObjects;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private bool isJumping = false;
    private int jumpCount;
    private bool isSprinting;
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

        ProcessInputs();

        AnimateFlip();

        SmallerJump();

        checkSprint();

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
        if(!isSprinting)
        {
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
            if(rb.velocity.x == 0)
            {
                animator.SetFloat("Speed", 0); //idle animation
            }
            else if(rb.velocity.x != 0)
            {
                animator.SetFloat("Speed", 1); //run animation
            }
        }
        else if(isSprinting)
        {
            rb.velocity = new Vector2(moveDirection.x * sprintSpeed, rb.velocity.y);
            if(rb.velocity.x == 0)
            {
                animator.SetFloat("Speed", 0); //idle animation
            }
            else if(rb.velocity.x != 0)
            {
                animator.SetFloat("Speed", 2); //sprinting animation
            }
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
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void SmallerJump()
    {
         if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private void checkSprint()
    {
        if(Input.GetButtonDown("Sprint"))
        {
            isSprinting = true;
        }
        if(Input.GetButtonUp("Sprint"))
        {
            isSprinting = false;
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
}
