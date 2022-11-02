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
    public int attackDamage = 20;

 
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            Attack();
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
