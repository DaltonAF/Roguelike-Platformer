using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobMovement : MonoBehaviour
{
    public bool mustPatrol;
    public float walkSpeed;

    private bool mustFlip;

    public Rigidbody2D rb;

    public Transform groundCheckPos;

    public LayerMask Ground;

    public Animator animator;

    void Start()
    {
        mustPatrol = true;
    }

    void Update()
    {
        if(mustPatrol)
        {
            Patrol();
        }
    }

    private void FixedUpdate()
    {
        if(mustPatrol)
        {
            mustFlip = !Physics2D.OverlapCircle(groundCheckPos.position, 0.01f, Ground);
        }
    }

    void Patrol()
    {
        if(mustFlip)
        {
            Flip();
        }

        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);

       /* if(rb.velocity.x == 0)
        {
            animator.SetFloat("Speed", 0); //idle animation
        }

        else if (rb.velocity.x != 0)
        {
            animator.SetFloat("Speed", 1); //moving animation
        }*/
    }

    private void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }
}
