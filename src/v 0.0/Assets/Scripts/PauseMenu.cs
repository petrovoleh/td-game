using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string sceneName;

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    // Update is called once per frame

    void Start()
    {
        GameIsPaused = false;
    }

    public void PauseGame()
    {
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Options()
    {
        
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
<<<<<<< Updated upstream:src/v 0.0/Assets/Scripts/PauseMenu.cs
=======

    public void OptionsBack(){
        optionsUI.SetActive(false);
    
    }
    public void Restart(){
        SceneManager.LoadScene("Map1");
    }
>>>>>>> Stashed changes:src/v 0.0/Assets/Scripts/Game/PauseMenu.cs
}