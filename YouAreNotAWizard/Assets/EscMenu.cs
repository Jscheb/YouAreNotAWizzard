using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscMenu : MonoBehaviour
{
    int level = 0;
    public static bool GameIsPaused = false;
    public GameObject escMenuUI;
    public GameObject settingsMenuUI;
    public GameObject UI;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Save();
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Save()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("Level", level);
        PlayerPrefs.Save();
    }

    public void LoadGame()
    {
        Time.timeScale = 1f;
        level = PlayerPrefs.GetInt("Level");
        SceneManager.LoadScene(level);

    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);

    }


    public void EndGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }

    public void Resume()
    {
        escMenuUI.SetActive(false);
        settingsMenuUI.SetActive(false);
        UI.SetActive(true);

        Time.timeScale = 1f;
        GameIsPaused = false;

    }


    public void Pause()
    {
        UI.SetActive(false);

        escMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }
}
