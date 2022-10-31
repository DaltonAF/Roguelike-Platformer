using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public TextMeshProUGUI hitPointsText;

    void Start()
    {
        currentPlayerHealth = maxPlayerHealth;
        healthbar.SetMaxHealth(maxPlayerHealth);
        spriteRend = GetComponent<SpriteRenderer>();
        hitPointsText.text = currentPlayerHealth.ToString();
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
        hitPointsText.text = currentPlayerHealth.ToString();
        StartCoroutine(Invulnerability());
    }

    public void HealDamage(int damage)
    {
        currentPlayerHealth += damage;
        hitPointsText.text = currentPlayerHealth.ToString();
        healthbar.SetHealth(currentPlayerHealth);
    }

    public void playerHealthLimits()
    {
        if (currentPlayerHealth > maxPlayerHealth)
        {
            currentPlayerHealth = maxPlayerHealth;
            hitPointsText.text = currentPlayerHealth.ToString();
        }
        else if (currentPlayerHealth < 0)
        {
            currentPlayerHealth = 0;
            hitPointsText.text = currentPlayerHealth.ToString();
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

