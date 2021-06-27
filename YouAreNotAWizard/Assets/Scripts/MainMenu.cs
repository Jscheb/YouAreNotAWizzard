using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    int level = 0;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadGame()
    {
        level = PlayerPrefs.GetInt("Level");
        SceneManager.LoadScene(level);

    }

   


    public void EndGame() 
    {
        Application.Quit();
    }
}
