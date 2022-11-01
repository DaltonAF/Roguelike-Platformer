using UnityEngine;
using System;

public class PlayerCollision : MonoBehaviour
{
    public PlayerHealth playerhealth;

    private void OnCollisionEnter2D(Collision2D col)
    {

        if(col.gameObject.tag == "Enemy")
        {
            if(col.gameObject.name == "Head Hitbox")
            {
                Debug.Log("collided with enemy's head hitbox");
                var enemy = col.gameObject.GetComponent<EnemyScript>();
                enemy.Kill();
            }
            else
            {
            playerhealth.TakeDamage(5);
            }

        }
    }
}
