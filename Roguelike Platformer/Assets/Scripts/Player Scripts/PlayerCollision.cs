using UnityEngine;
using System;

public class PlayerCollision : MonoBehaviour
{
    [Header("Scripts")]
    public EnemyScript enemyscript;
    public PlayerHealth playerhealth;

    [Header("Game Objects")]
    public GameObject player;
    public GameObject enemy;


    private void OnCollisionEnter2D(Collision2D col)
    { 
        if(col.gameObject.tag == "Enemy" && !enemyscript.isDead)
        {
            playerhealth.TakeDamage(5);
        }
    }
}
