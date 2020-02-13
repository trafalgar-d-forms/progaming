using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public static bool isGamePause = false;
    public GameObject pauseMenuUI;
    public GameObject gameUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameUI.SetActive(true);
        isGamePause = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameUI.SetActive(false);
        isGamePause = true;
    }

    public void Options()
    {

    }

    public void SaveAndQuit()
    {
        
    }
}
