using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {

        if ((Input.GetKeyDown(KeyCode.Escape)))
        {

            if (GameIsPaused)
            {
                Resume();
                pauseMenuUI.SetActive(false);

            }
            else
            {
                PauseFunc();
                pauseMenuUI.SetActive(true);
            }

        }

    }

    public void Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);

    }

    public void PauseFunc()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;

    }
    public void Quit()
    {
        Application.Quit();
    }
}