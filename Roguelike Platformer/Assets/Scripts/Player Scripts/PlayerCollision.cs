using UnityEngine;
using System;

public class PlayerCollision : MonoBehaviour
{
    [Header("Scripts")]
    public EnemyScript enemyscript;
    public PlayerHealth playerhealth;
    public PlayerMovement playermovement;

    [Header("Game Objects")]
    public GameObject player;
    public GameObject enemy;

    public Animator animator;
    public bool againstWall = false;


    private void OnCollisionEnter2D(Collision2D col)
    { 
        if(col.gameObject.tag == "Enemy" && !enemyscript.isDead)
        {
            playerhealth.TakeDamage(5);
        }
    }

    private void OnCollisionStay2D(Collision2D col)
    {
         if(col.gameObject.tag == "Wall")
        {
            againstWall = true;
            animator.SetFloat("Speed", 0); //idle animation
        }
        else
        {
            againstWall = false;
        }
    }
}
