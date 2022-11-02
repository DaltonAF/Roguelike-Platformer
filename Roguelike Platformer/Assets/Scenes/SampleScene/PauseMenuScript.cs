using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{

    public GameObject PauseMenu;
    public bool isPaused = false;

    public AudioSource Music;

    void Start()
    {
        PauseMenu.SetActive(false);
        Music = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {

            if(isPaused)
            {
                resumeGame();
            } 
            else 
            {
                pauseGame();
            }
        }
    }


    public void pauseGame()
    {
        PauseMenu.SetActive(true);

        Music.volume = 0.12f;

        Time.timeScale = 0f * Time.deltaTime;

        isPaused = true;
    }

    public void resumeGame()
    {
        PauseMenu.SetActive(false);

        Music.volume = 0.4f;

        Time.timeScale = 1f;

        isPaused = false;
    }

    public void goToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }
    
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
