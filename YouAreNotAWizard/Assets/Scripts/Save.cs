using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Save : MonoBehaviour
{
    int level = 0;
    private void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("Level", level);
        PlayerPrefs.Save();
    }
}
