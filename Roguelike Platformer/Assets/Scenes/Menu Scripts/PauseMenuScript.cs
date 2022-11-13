using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{

    public GameObject PauseMenu;
    public GameObject OptionsMenu;
    public static bool isPaused = false;

    public MusicPlayer musicplayer;

    void Start()
    {
        PauseMenu.SetActive(false);
        OptionsMenu.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {

            if(isPaused)
            {
                if(!OptionsMenu.activeInHierarchy)
                {
                    resumeGame();
                }
                else
                {
                    OptionsMenu.SetActive(false);
                    PauseMenu.SetActive(true);
                }

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

        musicplayer._AudioSource1.volume = 0.12f;

        Time.timeScale = 0f * Time.deltaTime;

        isPaused = true;
    }

    public void resumeGame()
    {
        PauseMenu.SetActive(false);

        musicplayer._AudioSource1.volume = 0.4f;

        Time.timeScale = 1f;

        isPaused = false;
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
        isPaused = false;
    }
    
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
