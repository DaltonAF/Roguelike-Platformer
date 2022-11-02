using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int maxHealth = 20;
    private int currentHealth;

    private SpriteRenderer spriteRend;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void EnemyTakeDamage(int damage)
    {
        currentHealth -= damage;

        //play hurt animation

        if(currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill(){
        //die animation
        Destroy(gameObject);
    }
}
