using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Anleitung : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
