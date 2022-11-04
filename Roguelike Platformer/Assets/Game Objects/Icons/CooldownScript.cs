using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CooldownScript : MonoBehaviour
{
    [SerializeField]
    private Image imageCooldown;
    [SerializeField]
    private TMP_Text textCooldown;

    public PlayerMovement playermovement;
    private float cooldownTimer = 0.0f;

    void Start()
    {
        textCooldown.gameObject.SetActive(false);
        imageCooldown.fillAmount = 0.0f;
    }

    void Update()
    {
        if(Input.GetButtonDown("Dash"))
        {
            UseDash();
        }

        if(!playermovement.canDash)
        {
            ApplyCooldown();
        }
    }

    public void ApplyCooldown()
    {
        cooldownTimer -= Time.deltaTime;

        if(cooldownTimer < 0.0f)
        {
            textCooldown.gameObject.SetActive(false);
            imageCooldown.fillAmount = 0.0f;
        }
        else
        {
            //textCooldown.text = Mathf.RoundToInt(cooldownTimer).ToString(); add if you want time in numbers for cooldown
            imageCooldown.fillAmount = cooldownTimer / playermovement.dashingCooldown;
        }
    }

    public void UseDash()
    {
        if(!playermovement.canDash)
        {
            //player tried to dash while on cooldown
            Debug.Log("Dash on cooldown!");
        }
        else
        {
            //textCooldown.gameObject.SetActive(true); add if you want time in numbers for cooldown
            cooldownTimer = playermovement.dashingCooldown;
        }
    }
}
