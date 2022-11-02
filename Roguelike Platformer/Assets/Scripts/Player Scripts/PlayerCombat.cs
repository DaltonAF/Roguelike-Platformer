using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    
    public Transform attackPoint;
    public LayerMask enemyLayers;

    [Header("Attack Values")]
    public float attackRange = 0.69f;
    public int attackDamage = 15;
    public float attackRate = 2f;

    private float nextAttackTime = 0f;

 
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack"); //play animation

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers); //detect enemies within a specific range

        foreach(Collider2D enemy in hitEnemies) //damage enemies in range
        {
            enemy.GetComponent<EnemyScript>().EnemyTakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
