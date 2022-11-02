using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathSceneScript : MonoBehaviour
{

    public PlayerHealth playerhealth;
    public GameObject DeathScreen;

    void Start()
    {
        DeathScreen.SetActive(false);
    }

    void Update()
    {
        if(playerhealth.currentPlayerHealth == 0)
        {
            gameOver();
        }
    }


    public void gameOver()
    {
        DeathScreen.SetActive(true);

        Time.timeScale = 0f * Time.deltaTime;
    }

    public void goToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }

}
