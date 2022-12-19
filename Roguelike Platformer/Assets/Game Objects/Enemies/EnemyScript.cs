using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int maxHealth = 20;
    private int currentHealth;
    public bool isDead = false;

    public Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void EnemyTakeDamage(int damage)
    {
        if (!isDead)
        {
            currentHealth -= damage;

            //play hurt animation
            animator.SetTrigger("Hurt");

            if(currentHealth <= 0)
            {
                Die();
            }
        }
    }

    public void Die(){
        //die animation
        Physics2D.IgnoreLayerCollision(10, 11, true);
        animator.SetBool("IsDead", true);
       
        isDead = true;
        FunctionTimer.Create(Kill, 0.9f);
    }

    public void Kill()
    {
        Physics2D.IgnoreLayerCollision(10, 11, false);
        Destroy(gameObject);
    }
}
