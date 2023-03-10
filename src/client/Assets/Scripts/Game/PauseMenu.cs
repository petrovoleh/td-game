using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject optionsUI;
    // Update is called once per frame

    void Start()
    {
        GameIsPaused = false;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = GameManager.Instance.FastForwardSpeed;
        GameIsPaused = false;
    }


    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    

    public void Options()
    {
        optionsUI.SetActive(true);
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void OptionsBack(){
        optionsUI.SetActive(false);
    
    }
    public void Restart(){
        SceneManager.LoadScene(LevelManager.Instance.MapNumber);
    }
}
