using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxPlayerHealth;
    public int currentPlayerHealth;

    public HealthBar healthbar;

    public UnitHealth unithealth;

    // Start is called before the first frame update
    void Start()
    {
        currentPlayerHealth = maxPlayerHealth;
        healthbar.SetMaxHealth(maxPlayerHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            unithealth.TakeDamage(20);
            unithealth.playerHealthLimits();
            Debug.Log(currentPlayerHealth);
        }

        if(Input.GetKeyDown(KeyCode.H))
        {
            unithealth.HealDamage(20);
            unithealth.playerHealthLimits();
            Debug.Log(currentPlayerHealth);
        }
    }
}
