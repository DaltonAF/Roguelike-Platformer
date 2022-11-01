using UnityEngine;
using System;

public class PlayerCollision : MonoBehaviour
{
    public PlayerHealth playerhealth;
    public GameObject player;
    public GameObject enemy;


    private void OnCollisionEnter2D(Collision2D col)
    {

        Debug.Log(player.transform.position.y);
        Debug.Log(enemy.transform.position.y);    

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
