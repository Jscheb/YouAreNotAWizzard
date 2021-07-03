using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    int level = 0;
    public GameObject mMenu;
    public GameObject anleitung;
    public void PlayGame()
    {
        mMenu.SetActive(false);
        anleitung.SetActive(true);
      //  if (Input.GetKeyDown(KeyCode.Mouse0)) {
      //      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      //     }
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
