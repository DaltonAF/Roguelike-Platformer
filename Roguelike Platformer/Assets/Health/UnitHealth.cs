using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth : MonoBehaviour
{

    public PlayerHealth playerhealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void TakeDamage(int damage)
    {
        playerhealth.currentPlayerHealth -= damage;
        playerhealth.healthbar.SetHealth(playerhealth.currentPlayerHealth);
    }

    public void HealDamage(int damage)
    {
        playerhealth.currentPlayerHealth += damage;
        playerhealth.healthbar.SetHealth(playerhealth.currentPlayerHealth);
    }

    public void playerHealthLimits()
    {
        if (playerhealth.currentPlayerHealth > playerhealth.maxPlayerHealth)
        {
            playerhealth.currentPlayerHealth = playerhealth.maxPlayerHealth;
        }
        else if (playerhealth.currentPlayerHealth < 0)
        {
            playerhealth.currentPlayerHealth = 0;
        }
    }
}
