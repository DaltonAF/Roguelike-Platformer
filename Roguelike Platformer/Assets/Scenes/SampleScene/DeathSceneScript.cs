using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathSceneScript : MonoBehaviour
{

    public PlayerHealth playerhealth;
    public GameObject DeathScreen;
    public static bool isDead = false;

    void Start()
    {
        DeathScreen.SetActive(false);
    }

    void Update()
    {
        if(playerhealth.currentPlayerHealth <= 0)
        {
            gameOver();
        }
    }

    public void gameOver()
    {
        DeathScreen.SetActive(true);

        isDead = true;        

        Time.timeScale = 0f * Time.deltaTime;
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
        isDead = false;
        Debug.Log(PauseMenuScript.isPaused);
        Debug.Log(isDead);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
