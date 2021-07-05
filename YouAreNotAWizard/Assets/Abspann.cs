using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Abspann : MonoBehaviour
{
    public GameObject A1;
    public GameObject A2;
    public GameObject A3;
    public GameObject A4;
    public GameObject A5;
    public int i = 0;
    public GameObject A;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (A.activeInHierarchy)
        {
            
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                i++;
                if (i == 5)
                {
                    A1.SetActive(true);
                }
                if (i == 7)
                {
                    A1.SetActive(false);
                    A2.SetActive(true);

                }
                if (i == 8)
                {
                    A2.SetActive(false);
                    A3.SetActive(true);

                }
                if (i == 12)
                {
                    A3.SetActive(false);
                    A4.SetActive(true);

                }
                if (i == 26)
                {
                    A4.SetActive(false);
                    A5.SetActive(true);

                }
                if (i == 28)
                {
                    SceneManager.LoadScene(0);
                    PlayerPrefs.SetInt("Level", 0);
                    PlayerPrefs.Save();
                    A5.SetActive(false);
                    A.SetActive(false);

                }
            }

        }
    }



}
