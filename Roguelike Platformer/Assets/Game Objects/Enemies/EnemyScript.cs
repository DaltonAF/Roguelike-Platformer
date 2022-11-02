using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int maxHealth = 20;
    private int currentHealth;

    public Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void EnemyTakeDamage(int damage)
    {
        currentHealth -= damage;

        //play hurt animation
        animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die(){
        //die animation
        animator.SetBool("IsDead", true);
       
        FunctionTimer.Create(Kill, 1.2f);
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
