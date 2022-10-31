using UnityEngine;
using System;

public class PlayerCollision : MonoBehaviour
{
    public PlayerHealth playerhealth;

    private void OnCollisionEnter2D(Collision2D col)
    {

        if(col.gameObject.tag == "Enemy")
        {
            playerhealth.TakeDamage(5);
        }
    }
}
