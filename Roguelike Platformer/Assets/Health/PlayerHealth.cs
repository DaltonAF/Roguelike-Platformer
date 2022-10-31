using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header ("Health")]
    public int maxPlayerHealth;
    public int currentPlayerHealth;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    [Header ("Health Scripts")]
    public HealthBar healthbar;

    void Start()
    {
        currentPlayerHealth = maxPlayerHealth;
        healthbar.SetMaxHealth(maxPlayerHealth);
        spriteRend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(20);
            playerHealthLimits();
            Debug.Log(currentPlayerHealth);
        }

        

        if(Input.GetKeyDown(KeyCode.H))
        {
            HealDamage(20);
            playerHealthLimits();
            Debug.Log(currentPlayerHealth);
        }
    }

        public void TakeDamage(int damage)
    {
        currentPlayerHealth -= damage;
        healthbar.SetHealth(currentPlayerHealth);
        StartCoroutine(Invulnerability());
    }

    public void HealDamage(int damage)
    {
        currentPlayerHealth += damage;
        healthbar.SetHealth(currentPlayerHealth);
    }

    public void playerHealthLimits()
    {
        if (currentPlayerHealth > maxPlayerHealth)
        {
            currentPlayerHealth = maxPlayerHealth;
        }
        else if (currentPlayerHealth < 0)
        {
            currentPlayerHealth = 0;
        }
    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);

        for(int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0.75f, 0.75f, 0.75f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }

        Physics2D.IgnoreLayerCollision(10, 11, false);
    }
}

