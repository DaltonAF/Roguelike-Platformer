using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{

    public GameObject PauseMenu;
    public bool isPaused = false;

    void Start()
    {
        PauseMenu.SetActive(false);
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

        Time.timeScale = 0f * Time.deltaTime;

        isPaused = true;
    }

    public void resumeGame()
    {
        PauseMenu.SetActive(false);

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
